using FitnessApp.Domain.Executions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.Database.Mappings
{
	public class WorkoutDayExecutionMapping : IEntityTypeConfiguration<WorkoutDayExecution>
	{
		public void Configure(EntityTypeBuilder<WorkoutDayExecution> builder)
		{
			builder.ToTable("WorkoutDayExecutions");
		}
	}
}
