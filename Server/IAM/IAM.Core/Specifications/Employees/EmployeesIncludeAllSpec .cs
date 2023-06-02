using Ardalis.Specification;
using IAM.Core.Enums;

namespace IAM.Core.Specifications.Employees
{
    public class EmployeesIncludeAllSpec : EmployeesIncludePersonalAndStaffingSpec
    {
        public EmployeesIncludeAllSpec(RoleType roleType, IsActive isActive = IsActive.Active) : base(isActive)
        {
            Query.Include(e => e.EmployeeHasEntRoles).ThenInclude(r => r.EntRole)
                 .Include(e => e.EmployeeHasRoles.Where(r => r.Role.Type == roleType)).ThenInclude(r => r.Role)
                 .AsSplitQuery();
        }
    }
}
