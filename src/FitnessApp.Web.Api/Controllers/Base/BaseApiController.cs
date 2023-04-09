using FitnessApp.Core.Application.Behaviours;
using FitnessApp.Web.Api.Models.Response;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Api.Controllers.Base
{
	[ApiController]
	public abstract class BaseApiController : ControllerBase
	{
		private readonly ILogger _logger;

		public BaseApiController(ILogger logger)
		{
			ArgumentNullException.ThrowIfNull(logger);

			_logger = logger;
		}
		protected async Task<IActionResult> ProcessResponse<T>(Func<Task<T>> processFunction)
		{
			try
			{
				return Ok(await processFunction());
			}
			catch (ValidationException validationEx)
			{
				if (validationEx.Errors.All(x => x.ErrorCode == ValidationErrorCodes.NotFound))
				{
					return NotFound(MapErrors(validationEx));
				}
				else
				{
					return BadRequest(MapErrors(validationEx));
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, new ServerErrorResponse { Message = ex.Message });
			}
		}

		protected async Task<IActionResult> ProcessResponse(Func<Task> processFunction)
		{
			try
			{
				await processFunction();
				return Ok();
			}
			catch (ValidationException validationEx)
			{
				if (validationEx.Errors.All(x => x.ErrorCode == ValidationErrorCodes.NotFound))
				{
					return NotFound(MapErrors(validationEx));
				}
				else
				{
					return BadRequest(MapErrors(validationEx));
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, new ServerErrorResponse { Message = ex.Message });
			}
		}

		private IEnumerable<ValidationErrorResponse> MapErrors(ValidationException validationEx)
		{
			return validationEx.Errors.Select(x => new ValidationErrorResponse
			{
				Property = x.PropertyName,
				Message = x.ErrorMessage
			});
		}
	}
}
