using FitnessApp.Domain.Executions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.Database.Mappings
{
	public class ExcerciseExecutionMapping : IEntityTypeConfiguration<ExcerciseExecution>
	{
		public void Configure(EntityTypeBuilder<ExcerciseExecution> builder)
		{
			builder.ToTable("ExcerciseExecutions");
		}
	}
}
