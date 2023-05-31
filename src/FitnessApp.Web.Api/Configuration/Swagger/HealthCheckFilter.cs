using Microsoft.OpenApi.Models;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Options;
using FitnessApp.Web.Api.Configuration.Options;

namespace FitnessApp.Web.Api.Configuration.Swagger
{
	public class HealthCheckFilter : IDocumentFilter
	{
		public HealthCheckFilter(IOptions<HealthCheckOptions> options)
		{
			_options = options.Value;
		}
		private readonly HealthCheckOptions _options;

		public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
		{
			var pathItem = new OpenApiPathItem();
			var operation = new OpenApiOperation();
			operation.Summary = "Checks all dependencies for status";
			operation.Tags.Add(new OpenApiTag { Name = "HealthCheck" });
			var properties = new Dictionary<string, OpenApiSchema>
			{
				{ "status", new OpenApiSchema() { Type = "string" } },
				{ "errors", new OpenApiSchema() { Type = "array" } }
			};

			var response = new OpenApiResponse();
			response.Content.Add("application/json", new OpenApiMediaType
			{
				Schema = new OpenApiSchema
				{
					Type = "object",
					AdditionalPropertiesAllowed = true,
					Properties = properties,
				}
			});

			operation.Responses.Add("200", response);
			pathItem.AddOperation(OperationType.Get, operation);

			swaggerDoc?.Paths.Add(_options.Endpoint, pathItem);
		}
	}
}
