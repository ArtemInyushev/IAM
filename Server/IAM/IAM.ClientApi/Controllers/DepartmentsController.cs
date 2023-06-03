using AutoMapper;
using IAM.ClientApi.Dtos;
using IAM.Core.Interfaces;
using IAM.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace IAM.ClientApi.Controllers
{
    public class DepartmentsController : BaseController<DepartmentsController>
    {
        private readonly IRepository<Department> _departmentsRepository;
        private readonly IMapper _mapper;

        public DepartmentsController(
            IRepository<Department> departmentsRepository,
            IMapper mapper,
            ILogger<DepartmentsController> logger) : base(logger)
        {
            _departmentsRepository = departmentsRepository;
            _mapper = mapper;
        }

        [HttpGet("Tree")]
        public async Task<IActionResult> GetTree()
        {
            var departments = await _departmentsRepository.ListAsync();
            var tree = departments.GenerateTree(_mapper);
            return Ok(tree);
        }
    }
}
