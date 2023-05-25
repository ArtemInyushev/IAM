using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IAM.ClientApi.Controllers
{
    [AllowAnonymous]
    public class TestController : BaseController<TestController>
    {
        public TestController(ILogger<TestController> logger) : base(logger) { }

        [HttpGet("[action]")]
        public IActionResult Test()
        {
            return Ok("test response");
        }
    }
}
