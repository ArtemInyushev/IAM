using Ardalis.Specification;
using AutoMapper;
using Azure.Identity;
using IAM.Application.Interfaces;
using IAM.Application.Options;
using IAM.Core.Enums;
using IAM.Core.Interfaces;
using IAM.Core.Models;
using IAM.Core.Specifications.Employees;
using IAM.Core.Specifications.Roles;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using System.Data;
using System.Diagnostics;

namespace IAM.Application.Services
{
    public class AdSyncService : IAdSyncService
    {
        private readonly IRepository<Employee> _employeesRepository;
        private readonly IRepository<Role> _rolesRepository;
        private readonly IRepository<Staffing> _staffingsRepository;
        private readonly IRepository<Personal> _personalsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AdSyncService> _logger;

        private readonly GraphServiceClient _graphServiceClient;

        public AdSyncService(
            IRepository<Employee> employeesRepository,
            IRepository<Role> rolesRepository,
            IRepository<Staffing> staffingsRepository,
            IRepository<Personal> personalsRepository,
            IMapper mapper,
            IOptions<AdOptions> adOptions, 
            ILogger<AdSyncService> logger
            )
        {
            _employeesRepository = employeesRepository;
            _rolesRepository = rolesRepository;
            _staffingsRepository = staffingsRepository;
            _personalsRepository = personalsRepository;
            _mapper = mapper;
            _logger = logger;

            var options = adOptions.Value;
            var credentials = new ClientSecretCredential(options.TenantId, options.ClientId, options.ClientSecret);
            _graphServiceClient = new GraphServiceClient(credentials);
        }

        public async Task SyncEmployeesAndGroups()
        {
            try
            {
                var sw = Stopwatch.StartNew();

                await SyncGroups();
                await SyncEmployees();                

                sw.Stop();
                _logger.LogInformation("AD synchronization was finished in {ElapsedMilliseconds}ms", sw.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error during AD synchronization - {Message}", ex.Message);
            }
        }

        private async Task SyncEmployees()
        {
            var userCollection = await _graphServiceClient.Users.GetAsync(requestConfiguration =>
            {
                requestConfiguration.QueryParameters.Filter = "startsWith(employeeId, '1001') and accountEnabled eq true";
                requestConfiguration.QueryParameters.Expand = new string[] { "memberOf($select=id)" };
                requestConfiguration.QueryParameters.Select = new string[]
                {
                        "givenName",
                        "surname",
                        "displayName",
                        "jobTitle",
                        "employeeId",
                        "mailNickname",
                        "accountEnabled",
                        "memberOf"
                };
            });
            var users = userCollection.Value;

            var employees = await _employeesRepository.ListAsync(new EmployeesIncludeAllSpec());
            var staffings = await _staffingsRepository.ListAsync();
            var roles = await _rolesRepository.ListAsync();

            foreach (var user in users)
            {
                var employee = employees.FirstOrDefault(e => e.EmployeeIdentifier.ToString() == user.EmployeeId);
                // Case 1: add missings user data and his groups
                if (employee is null) 
                {
                    // Fill up user data
                    var newEmployee = _mapper.Map<Employee>(user);

                    var newPersonal = _mapper.Map<Personal>(user);
                    newEmployee.Personal = newPersonal;

                    var staffing = staffings.SingleOrDefault(s => s.StaffingCode == int.Parse(user.JobTitle)) 
                        ?? throw new ArgumentNullException("Any staffing with StaffingCode={JobTitle}", user.JobTitle);
                    newEmployee.Staffing = staffing;

                    // Add roles
                    var newRoles = await _rolesRepository.ListAsync(new RolesByEnternalIdsSpec(user.MemberOf.Select(m => Guid.Parse(m.Id))));
                    foreach (var role in newRoles)
                    {
                        newEmployee.EmployeeHasRoles.Add(
                            new EmployeeHasRole
                            {
                                EmployeeId = newEmployee.Id,
                                RoleId = role.Id,
                                Status = RoleStatus.Active
                            }
                        );
                    }

                    await _employeesRepository.AddAsync(newEmployee, false);
                }
                else // Case 2: update user data and his groups if needed
                {
                    // Update user data
                    var updatedPersonal = _mapper.Map<Personal>(user);
                    employee.AccountName = user.MailNickname;
                    employee.Personal.FirstName = updatedPersonal.FirstName;
                    employee.Personal.LastName = updatedPersonal.LastName;
                    employee.Personal.DisplayName = updatedPersonal.DisplayName;

                    // Add missing groups for user
                    foreach (var groupdId in user.MemberOf.Select(m => Guid.Parse(m.Id)))
                    {
                        var employeeHasRole = employee.EmployeeHasRoles.FirstOrDefault(e => e.Role.ExternaId == groupdId);
                        if (employeeHasRole is null) // Assign role to employee
                        {
                            var role = roles.FirstOrDefault(r => r.ExternaId == groupdId) 
                                ?? throw new ArgumentNullException("Any role with ExternaId={groupdId}", groupdId.ToString());

                            employee.EmployeeHasRoles.Add(
                                new EmployeeHasRole
                                {
                                    EmployeeId = employee.Id,
                                    RoleId = role.Id,
                                    Status = RoleStatus.Active
                                }
                            );
                        }
                        else // Update assigned role status
                        {
                            switch (employeeHasRole.Status)
                            {
                                case RoleStatus.Active:
                                case RoleStatus.ToDelete:
                                    break;
                                case RoleStatus.Deleted:
                                case RoleStatus.ToCreate:
                                    employeeHasRole.Status = RoleStatus.Active;
                                    break;
                            }
                        }
                    }

                    await _employeesRepository.SaveChangesAsync();

                    // Remove extra groups for user
                    foreach (var employeeHasRole in employee.EmployeeHasRoles)
                    {
                        if (!user.MemberOf.Any(m => m.Id == employeeHasRole.Role.ExternaId.ToString()))
                        {
                            employeeHasRole.Status = RoleStatus.Deleted;
                        }
                    }

                    await _employeesRepository.SaveChangesAsync();
                }
            }

            foreach (var employee in employees)
            {
                // Case 1: remove extra users
                if (!users.Any(u => u.EmployeeId == employee.EmployeeIdentifier.ToString()))
                {
                    // Delete all roles
                    employee.EmployeeHasEntRoles.Clear();
                    foreach (var employeeHasRole in employee.EmployeeHasRoles)
                    {
                        employeeHasRole.Status = RoleStatus.ToDelete;
                    }
                    employee.IsActive = false;
                }
            }

            await _employeesRepository.SaveChangesAsync();
            await _personalsRepository.SaveChangesAsync();
        }

        private async Task SyncGroups()
        {
            var roles = await _rolesRepository.ListAsync();
            var groupCollection = await _graphServiceClient.Groups.GetAsync(requestConfiguration =>
            {
                requestConfiguration.QueryParameters.Select = new string[]
                {
                        "id",
                        "displayName",
                        "description",
                };
            });
            var groups = groupCollection.Value; 

            // Add missing groups
            foreach (var group in groups)
            {
                if (!roles.Any(r => r.ExternaId.ToString() == group.Id))
                {
                    var newRole = _mapper.Map<Role>(group);
                    newRole.Type = TypeRole.AD;
                    await _rolesRepository.AddAsync(newRole, false);
                }
            }

            // Remove extra groups
            foreach (var role in roles)
            {
                if (!groups.Any(g => g.Id == role.ExternaId.ToString()))
                {
                    await _rolesRepository.DeleteAsync(role);
                }
            }

            await _rolesRepository.SaveChangesAsync();
        }
    }
}
