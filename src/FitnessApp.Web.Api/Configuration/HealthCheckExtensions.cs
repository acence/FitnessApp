using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.Web.Api.Configuration
{
	public static class HealthCheckExtensions
	{
		public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
		{
			services
				.Configure<Options.HealthCheckOptions>(configuration.GetSection("HealthCheck"));
			services
				.AddHealthChecks()
				.AddSqlServer(configuration["ConnectionStrings:FitnessAppDatabaseConnection"]!, name: "SqlServer");

			return services;
		}

		public static WebApplication MapHealthCheck(this WebApplication app, IConfiguration configuration)
		{
			app.MapHealthChecks(configuration["HealthCheck:Endpoint"]!, new HealthCheckOptions
			{
				ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
			});

			return app;
		}
	}
}
