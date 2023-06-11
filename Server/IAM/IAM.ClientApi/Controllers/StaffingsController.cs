using AutoMapper;
using IAM.ClientApi.Dtos;
using IAM.Core.Interfaces;
using IAM.Core.Models;
using IAM.Core.Specifications.Staffings;
using Microsoft.AspNetCore.Mvc;

namespace IAM.ClientApi.Controllers
{
    public class StaffingsController : BaseController<StaffingsController>
    {
        private readonly IRepository<Staffing> _staffingsRepository;
        private readonly IMapper _mapper;

        public StaffingsController(
            IRepository<Staffing> staffingsRepository,
            IMapper mapper,
            ILogger<StaffingsController> logger) : base(logger)
        {
            _staffingsRepository = staffingsRepository;
            _mapper = mapper;
        }

        [HttpGet("DepartmentId")]
        public async Task<IActionResult> GetByDepartmentId(long departmentId)
        {
            var entRoles = (await _staffingsRepository.ListAsync(new StaffingsByDepartmentIdSpec(departmentId)))
                .Select(e => _mapper.Map<StaffingDto>(e));
            return Ok(entRoles);
        }
    }
}
