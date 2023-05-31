using Microsoft.OpenApi.Models;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FitnessApp.Web.Api.Configuration.Swagger
{
	public class HealthCheckFilter : IDocumentFilter
	{
		public const string HealthCheckEndpoint = @"/api/health-check";

		public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
		{
			var pathItem = new OpenApiPathItem();
			var operation = new OpenApiOperation();
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

			swaggerDoc?.Paths.Add(HealthCheckEndpoint, pathItem);
		}
	}
}
