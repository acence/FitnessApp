namespace FitnessApp.Web.Api.Configuration
{
	public static class HealthCheckExtensions
	{
		public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
		{
			services
				.AddHealthChecks()
				.AddSqlServer(configuration["ConnectionStrings:FitnessAppDatabaseConnection"], name: "SqlServer");

			return services;
		}
	}
}
