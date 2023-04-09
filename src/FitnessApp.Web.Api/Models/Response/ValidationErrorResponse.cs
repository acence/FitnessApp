using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Web.Api.Models.Response
{
    public class ValidationErrorResponse
    {
        /// <summary>
        /// Property for which the validation failed
        /// </summary>
        [Required]
        public string Property { get; set; } = null!;

        /// <summary>
        /// Description of what failed
        /// </summary>
        [Required]
        public string Message { get; set; } = null!;
    }
}
