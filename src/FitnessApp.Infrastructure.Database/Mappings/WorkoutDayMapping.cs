using FitnessApp.Domain;
using FitnessApp.Domain.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappings
{
	public class WorkoutDayMapping : IEntityTypeConfiguration<WorkoutDay>
	{
		public void Configure(EntityTypeBuilder<WorkoutDay> builder)
		{
			builder
				.ToTable("WorkoutDays");
			builder
				.HasKey(x => x.Id);
			builder
				.Property(x => x.Flags)
				.IsRequired();
			builder
				.HasMany(x => x.Workouts)
				.WithOne(x => x.WorkoutDay)
				.OnDelete(DeleteBehavior.Restrict);
			builder
				.HasMany(x => x.Excercises)
				.WithOne(x => x.WorkoutDay)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
