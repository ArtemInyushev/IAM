using AutoMapper;
using IAM.ClientApi.Dtos;
using IAM.Core.Interfaces;
using IAM.Core.Models;
using IAM.Core.Specifications.Employees;
using Microsoft.AspNetCore.Mvc;

namespace IAM.ClientApi.Controllers
{
    public class EmployeesController : BaseController<EmployeesController>
    {
        private readonly IRepository<Employee> _employeesRepository;
        private readonly IMapper _mapper;

        public EmployeesController(
            IRepository<Employee> employeesRepository,
            IMapper mapper,
            ILogger<EmployeesController> logger) : base(logger)
        {
            _employeesRepository = employeesRepository;
            _mapper = mapper;
        }

        [HttpGet("DepartmentId")]
        public async Task<IActionResult> GetByDepartmentId(long departmentId)
        {
            var employees = (await _employeesRepository.ListAsync(new EmployeesByDepartmentIdSpec(departmentId)))
                .Select(e => _mapper.Map<EmployeeDto>(e));
            return Ok(employees);
        }
    }
}
