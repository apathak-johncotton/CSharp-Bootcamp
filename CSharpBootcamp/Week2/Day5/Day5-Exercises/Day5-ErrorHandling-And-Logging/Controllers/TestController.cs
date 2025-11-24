using Microsoft.AspNetCore.Mvc;

namespace Day5_ErrorHandling_And_Logging.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("ok")]
        public IActionResult GetOk()
        {
            _logger.LogInformation("GET /api/test/ok called");
            return Ok(new { Message = "All good!" });
        }

        [HttpGet("error")]
        public IActionResult GetError()
        {
            _logger.LogInformation("GET /api/test/error called, about to throw.");
            throw new InvalidOperationException("Something went wrong in the controller.");
        }
    }
}
