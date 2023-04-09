using FitnessApp.Domain.Executions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mappings
{
	public class WorkoutDayExecutionMapping : IEntityTypeConfiguration<WorkoutDayExecution>
	{
		public void Configure(EntityTypeBuilder<WorkoutDayExecution> builder)
		{
			builder
				.ToTable("WorkoutDayExecutions");
			builder
				.HasMany(x => x.ExcerciseExecutions)
				.WithOne(x => x.WorkoutDay)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
