using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FitnessApp.Infrastructure.Database.Configuration;

namespace FitnessApp.IoC.Web.Api
{
	public static class WebApiDependencyExtensions
	{
		public static IServiceCollection AddWebApiDependencies(this IServiceCollection services, IConfiguration configuration)
		{
			return services.AddDatabaseServices(configuration);
		}
	}
}