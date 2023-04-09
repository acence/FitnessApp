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
	public class ExcerciseMapping : IEntityTypeConfiguration<Excercise>
	{
		public void Configure(EntityTypeBuilder<Excercise> builder)
		{
			builder
				.ToTable("Excercises");
			builder
				.Property(x => x.Name)
				.HasMaxLength(150)
				.IsRequired();
			builder
				.Property(x => x.Description)
				.HasMaxLength(1000);
			builder
				.Property(x => x.Image)
				.HasMaxLength(50);
			builder.HasMany(x => x.WorkoutExcercises)
				.WithOne(x => x.Excercise)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
