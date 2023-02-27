using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Api.Controllers
{
	[ApiController]
	[Route("/api/health-check")]
	public class HealthCheckController : ControllerBase
	{
		private readonly ILogger<HealthCheckController> _logger;

		public HealthCheckController(ILogger<HealthCheckController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		[Route("is-alive")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
		public IActionResult GetIsAlive()
		{
			return new NoContentResult();
		}
	}
}