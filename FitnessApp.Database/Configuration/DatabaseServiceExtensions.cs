using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.Database.Interfaces;

namespace FitnessApp.Database.Configuration
{
	public static class DatabaseServiceExtensions
	{
		public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("FitnessAppConnectionService");

			services.AddDbContext<IDatabaseContext, DatabaseContext>(options =>
			{
				options.UseSqlServer(connectionString);
			});

			return services;
		}
	}
}
