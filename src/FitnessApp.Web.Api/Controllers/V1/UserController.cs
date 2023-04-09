using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Api.Controllers.V1
{
	[ApiVersion("1")]
	[Route("api/v{version:apiVersion}/users")]
	[ApiController]
	public class UserController : ControllerBase
	{
		public UserController()
		{

		}
	}
}
