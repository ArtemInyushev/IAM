using AutoMapper;
using IAM.ClientApi.Dtos;
using IAM.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace IAM.ClientApi.Controllers
{
    public class RolesController : BaseController<RolesController>
    {
        private readonly IMapper _mapper;

        public RolesController(
            IMapper mapper, 
            ILogger<RolesController> logger) : base(logger)
        {
            _mapper = mapper;
        }

        [HttpGet("Types")]
        public IActionResult GetRoleTypes()
        {
            var enumValues = Enum.GetValues(typeof(RoleType)).Cast<RoleType>().Select(r => _mapper.Map<RoleTypeDto>(r));
            return Ok(enumValues);
        }
    }
}
