using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthCheckController : ControllerBase
    {
        private readonly ILogger<HealthCheckController> _logger;

        public HealthCheckController(ILogger<HealthCheckController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetHealthCheck()
        {
           return new NoContentResult();
        }
    }
}