using AutoMapper;
using IAM.ClientApi.Dtos;
using IAM.Core.Enums;
using IAM.Core.Interfaces;
using IAM.Core.Models;
using IAM.Core.Specifications.Roles;
using Microsoft.AspNetCore.Mvc;

namespace IAM.ClientApi.Controllers
{
    public class RolesController : BaseController<RolesController>
    {
        private readonly IRepository<Role> _rolesRepository;
        private readonly IMapper _mapper;

        public RolesController(
            IRepository<Role> rolesRepository,
            IMapper mapper, 
            ILogger<RolesController> logger) : base(logger)
        {
            _rolesRepository = rolesRepository;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Search(RoleType type, string query)
        {
            var roles = (await _rolesRepository.ListAsync(new RolesByQuerySpec(type, query ?? "", 100)))
                .Select(e => _mapper.Map<RoleDto>(e));
            return Ok(roles);
        }

        [HttpGet("Types")]
        public IActionResult GetRoleTypes()
        {
            var enumValues = Enum.GetValues(typeof(RoleType)).Cast<RoleType>().Select(r => _mapper.Map<RoleTypeDto>(r));
            return Ok(enumValues);
        }
    }
}
