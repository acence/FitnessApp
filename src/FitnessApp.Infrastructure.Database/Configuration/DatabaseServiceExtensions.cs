using FitnessApp.Database;
using FitnessApp.Infrastructure.Database.Base;
using FitnessApp.Infrastructure.Database.Interfaces.Base;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FitnessApp.Infrastructure.Database.Configuration
{
	public static class DatabaseServiceExtensions
	{
		public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("FitnessAppConnectionService");

			services.AddDbContext<IDatabaseContext, DatabaseContext>(options =>
			{
				options.UseSqlServer(connectionString);
				options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
			});

			var typesToRegister = Assembly.GetExecutingAssembly()
				.GetTypes()
				.Where(type => !string.IsNullOrEmpty(type.Namespace)
					&& type.BaseType != null
					&& type.BaseType.IsGenericType
					&& type.BaseType.GetGenericTypeDefinition() == typeof(BaseRepository<>));

			foreach (var type in typesToRegister)
			{
				var implementedInterface = type.GetInterfaces()
					.Where(x => x.GetInterfaces().Any(y => y.GetGenericTypeDefinition() == typeof(IBaseRepository<>)))
					.First();

				services.AddTransient(implementedInterface, type);
			}

			return services;
		}
	}
}
