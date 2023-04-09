using FitnessApp.Domain.Executions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mappings
{
	public class WorkoutDayExecutionMapping : IEntityTypeConfiguration<WorkoutDayExecution>
	{
		public void Configure(EntityTypeBuilder<WorkoutDayExecution> builder)
		{
			builder.ToTable("WorkoutDayExecutions");
		}
	}
}
