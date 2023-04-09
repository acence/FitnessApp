using AutoMapper;
using FitnessApp.Core.Application.UseCases.WorkoutPlan.Handlers;
using FitnessApp.Domain.Authentication;
using FitnessApp.Web.Api.Controllers.Base;
using FitnessApp.Web.Api.Models.Response;
using FitnessApp.Web.Api.Models.Response.Workouts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Api.Controllers.V1
{
	[ApiVersion("1")]
	[Route("api/v{version:apiVersion}/workout-plans")]
	[ApiController]
	public class WorkoutPlansController : BaseApiController
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public WorkoutPlansController(IMediator mediator, IMapper mapper, ILogger<WorkoutPlansController> logger) : base(logger)
		{
			ArgumentNullException.ThrowIfNull(mediator);
			ArgumentNullException.ThrowIfNull(mapper);

			_mediator = mediator;
			_mapper = mapper;
		}

		/// <summary>
		/// Retrieves a list of workout plans
		/// </summary>
		/// <returns>List of workout plans</returns>
		[HttpGet]
		[Route("")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<WorkoutPlanResponse>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<ValidationErrorResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ServerErrorResponse))]
		public async Task<IActionResult> GetWorkoutPlans()
		{
			var query = new GetWorkoutPlansForUser.Query();

			return await ProcessResponse(async () =>
			{
				var result = await _mediator.Send(query);
				return _mapper.Map<IEnumerable<WorkoutPlanResponse>>(result);
			});
		}
	}
}
