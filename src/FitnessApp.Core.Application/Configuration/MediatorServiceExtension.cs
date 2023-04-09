using FitnessApp.Core.Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FitnessApp.Core.Application.Configuration
{
	public static class MediatorServiceExtension
	{
		public static IServiceCollection AddMediatorServices(this IServiceCollection services)
		{
			services
				.AddMediatR(configuration =>
				{
					configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
				})
				.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

			return services;
		}

		public static IServiceCollection AddValidators(this IServiceCollection services)
		{
			var typesToRegister = Assembly.GetExecutingAssembly()
				.GetTypes()
				.Where(type => !string.IsNullOrEmpty(type.Namespace)
					&& type.BaseType != null
					&& type.BaseType.IsGenericType
					&& type.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>));

			foreach (var type in typesToRegister)
			{
				var validationInterface = type.GetInterfaces()
					.Where(x => x.IsGenericType
						&& x.GetGenericTypeDefinition() == typeof(IValidator<>))
					.First();

				services.AddTransient(validationInterface, type);
			}

			return services;
		}
	}
}
