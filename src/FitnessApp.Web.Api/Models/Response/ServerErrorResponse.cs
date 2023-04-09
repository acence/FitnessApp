using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Web.Api.Models.Response
{
	public class ServerErrorResponse
	{
		/// <summary>
		/// Exception message
		/// </summary>
		[Required]
		public string Message { get; set; } = null!;
	}
}
