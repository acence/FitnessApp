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
	public class WorkoutPlanMapping : IEntityTypeConfiguration<WorkoutPlan>
	{
		public void Configure(EntityTypeBuilder<WorkoutPlan> builder)
		{
			builder.ToTable("WorkoutPlans");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
		}
	}
}
