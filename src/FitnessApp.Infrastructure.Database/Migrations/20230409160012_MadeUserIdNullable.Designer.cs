﻿// <auto-generated />
using System;
using FitnessApp.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitnessApp.Infrastructure.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230409160012_MadeUserIdNullable")]
    partial class MadeUserIdNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BodyPartExcercise", b =>
                {
                    b.Property<int>("BodyPartsId")
                        .HasColumnType("int");

                    b.Property<int>("ExcercisesId")
                        .HasColumnType("int");

                    b.HasKey("BodyPartsId", "ExcercisesId");

                    b.HasIndex("ExcercisesId");

                    b.ToTable("BodyPartExcercise");
                });

            modelBuilder.Entity("FitnessApp.Domain.Authentication.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("FitnessApp.Domain.BodyPart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Intensity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("BodyParts", (string)null);
                });

            modelBuilder.Entity("FitnessApp.Domain.Excercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("Flags")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Excercises", (string)null);
                });

            modelBuilder.Entity("FitnessApp.Domain.Executions.ExcerciseExecution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExcerciseId")
                        .HasColumnType("int");

                    b.Property<int>("Repetitions")
                        .HasColumnType("int");

                    b.Property<int>("Series")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.Property<int>("WorkoutDayId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExcerciseId");

                    b.HasIndex("WorkoutDayId");

                    b.ToTable("ExcerciseExecutions", (string)null);
                });

            modelBuilder.Entity("FitnessApp.Domain.Executions.WorkoutDayExecution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("WorkoutDayId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutDayId");

                    b.ToTable("WorkoutDayExecutions", (string)null);
                });

            modelBuilder.Entity("FitnessApp.Domain.WorkoutDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<int>("Flags")
                        .HasColumnType("int");

                    b.Property<int>("WorkoutPlanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutPlanId");

                    b.ToTable("WorkoutDays", (string)null);
                });

            modelBuilder.Entity("FitnessApp.Domain.WorkoutExcercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExcerciseId")
                        .HasColumnType("int");

                    b.Property<int>("Repetitions")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("RestBetweenSets")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("RestUntilNextExcercise")
                        .HasColumnType("time");

                    b.Property<int>("Series")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.Property<int>("WorkoutDayId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExcerciseId");

                    b.HasIndex("WorkoutDayId");

                    b.ToTable("WorkoutExcercises", (string)null);
                });

            modelBuilder.Entity("FitnessApp.Domain.WorkoutPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Flags")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WorkoutPlans", (string)null);
                });

            modelBuilder.Entity("BodyPartExcercise", b =>
                {
                    b.HasOne("FitnessApp.Domain.BodyPart", null)
                        .WithMany()
                        .HasForeignKey("BodyPartsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessApp.Domain.Excercise", null)
                        .WithMany()
                        .HasForeignKey("ExcercisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FitnessApp.Domain.Executions.ExcerciseExecution", b =>
                {
                    b.HasOne("FitnessApp.Domain.WorkoutExcercise", "Excercise")
                        .WithMany("ExcerciseExecutions")
                        .HasForeignKey("ExcerciseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FitnessApp.Domain.Executions.WorkoutDayExecution", "WorkoutDay")
                        .WithMany("ExcerciseExecutions")
                        .HasForeignKey("WorkoutDayId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Excercise");

                    b.Navigation("WorkoutDay");
                });

            modelBuilder.Entity("FitnessApp.Domain.Executions.WorkoutDayExecution", b =>
                {
                    b.HasOne("FitnessApp.Domain.WorkoutDay", "WorkoutDay")
                        .WithMany("Workouts")
                        .HasForeignKey("WorkoutDayId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("WorkoutDay");
                });

            modelBuilder.Entity("FitnessApp.Domain.WorkoutDay", b =>
                {
                    b.HasOne("FitnessApp.Domain.WorkoutPlan", "WorkoutPlan")
                        .WithMany("WorkoutDays")
                        .HasForeignKey("WorkoutPlanId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("WorkoutPlan");
                });

            modelBuilder.Entity("FitnessApp.Domain.WorkoutExcercise", b =>
                {
                    b.HasOne("FitnessApp.Domain.Excercise", "Excercise")
                        .WithMany("WorkoutExcercises")
                        .HasForeignKey("ExcerciseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FitnessApp.Domain.WorkoutDay", "WorkoutDay")
                        .WithMany("Excercises")
                        .HasForeignKey("WorkoutDayId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Excercise");

                    b.Navigation("WorkoutDay");
                });

            modelBuilder.Entity("FitnessApp.Domain.WorkoutPlan", b =>
                {
                    b.HasOne("FitnessApp.Domain.Authentication.User", "User")
                        .WithMany("WorkoutPlans")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessApp.Domain.Authentication.User", b =>
                {
                    b.Navigation("WorkoutPlans");
                });

            modelBuilder.Entity("FitnessApp.Domain.Excercise", b =>
                {
                    b.Navigation("WorkoutExcercises");
                });

            modelBuilder.Entity("FitnessApp.Domain.Executions.WorkoutDayExecution", b =>
                {
                    b.Navigation("ExcerciseExecutions");
                });

            modelBuilder.Entity("FitnessApp.Domain.WorkoutDay", b =>
                {
                    b.Navigation("Excercises");

                    b.Navigation("Workouts");
                });

            modelBuilder.Entity("FitnessApp.Domain.WorkoutExcercise", b =>
                {
                    b.Navigation("ExcerciseExecutions");
                });

            modelBuilder.Entity("FitnessApp.Domain.WorkoutPlan", b =>
                {
                    b.Navigation("WorkoutDays");
                });
#pragma warning restore 612, 618
        }
    }
}
