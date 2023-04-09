using FitnessApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.Infrastructure.Database.Mappings
{
	public class WorkoutExcerciseMapping : IEntityTypeConfiguration<WorkoutExcercise>
	{
		public void Configure(EntityTypeBuilder<WorkoutExcercise> builder)
		{
			builder
				.ToTable("WorkoutExcercises");
			builder
				.HasKey(x => x.Id);

			builder
				.HasMany(x => x.ExcerciseExecutions)
				.WithOne(x => x.Excercise)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
