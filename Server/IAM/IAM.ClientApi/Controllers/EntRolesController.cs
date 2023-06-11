using AutoMapper;
using IAM.ClientApi.Dtos;
using IAM.Core.Interfaces;
using IAM.Core.Models;
using IAM.Core.Specifications.EntRoles;
using Microsoft.AspNetCore.Mvc;

namespace IAM.ClientApi.Controllers
{
    public class EntRolesController : BaseController<EntRolesController>
    {
        private readonly IRepository<EntRole> _entRolesRepository;
        private readonly IMapper _mapper;

        public EntRolesController(
            IRepository<EntRole> entRolesRepository,
            IMapper mapper,
            ILogger<EntRolesController> logger) : base(logger)
        {
            _entRolesRepository = entRolesRepository;
            _mapper = mapper;
        }

        [HttpGet("DepartmentId")]
        public async Task<IActionResult> GetByDepartmentId(long departmentId)
        {
            var entRoles = (await _entRolesRepository.ListAsync(new EntRolesByDepartmentIdSpec(departmentId)))
                .Select(e => _mapper.Map<EntRoleDto>(e));
            return Ok(entRoles);
        }
    }
}
