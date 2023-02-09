﻿using FitnessApp.Domain;
using FitnessApp.Domain.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Database.Mappings
{
	public class WorkoutDayMapping : IEntityTypeConfiguration<WorkoutDay>
	{
		public void Configure(EntityTypeBuilder<WorkoutDay> builder)
		{
			builder.ToTable("WorkoutDays");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Flags);
		}
	}
}
