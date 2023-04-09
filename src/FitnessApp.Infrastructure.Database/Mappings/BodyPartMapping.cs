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
	public class BodyPartMapping : IEntityTypeConfiguration<BodyPart>
	{
		public void Configure(EntityTypeBuilder<BodyPart> builder)
		{
			builder
				.ToTable("BodyParts");
			builder
				.Property(x => x.Name)
				.HasMaxLength(150)
				.IsRequired();
			builder
				.Property(x => x.Image)
				.HasMaxLength(50);
			builder
				.HasMany(x => x.Excercises)
				.WithMany(x => x.BodyParts);
		}
	}
}
