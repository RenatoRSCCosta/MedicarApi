﻿// <auto-generated />
using System;
using Medicar.Infrastructure.Contexs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Medicar.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231002203021_AlterScheduleDateType")]
    partial class AlterScheduleDateType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Medicar_API.Domain.Entities.Consultation", b =>
                {
                    b.Property<int>("ConsultationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ConsultationId"));

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("integer");

                    b.Property<int>("SlotId")
                        .HasColumnType("integer");

                    b.HasKey("ConsultationId");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("SlotId", "ScheduleId")
                        .IsUnique();

                    b.ToTable("Consultations");
                });

            modelBuilder.Entity("Medicar_API.Domain.Entities.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DoctorId"));

                    b.Property<string>("Crm")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar");

                    b.Property<int>("SpecialtyId")
                        .HasColumnType("integer");

                    b.HasKey("DoctorId");

                    b.HasIndex("Crm")
                        .IsUnique();

                    b.HasIndex("SpecialtyId")
                        .IsUnique();

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Medicar_API.Domain.Entities.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ScheduleId"));

                    b.Property<bool>("Available")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.HasKey("ScheduleId");

                    b.HasIndex("DoctorId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Medicar_API.Domain.Entities.Slot", b =>
                {
                    b.Property<int>("SlotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SlotId"));

                    b.Property<bool>("Available")
                        .HasColumnType("boolean");

                    b.Property<TimeOnly>("Hour")
                        .HasColumnType("time without time zone");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("integer");

                    b.HasKey("SlotId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Slots");
                });

            modelBuilder.Entity("Medicar_API.Domain.Entities.Specialty", b =>
                {
                    b.Property<int>("SpecialtyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SpecialtyId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("SpecialtyId");

                    b.ToTable("Specialtys");
                });

            modelBuilder.Entity("Medicar_API.Domain.Entities.Consultation", b =>
                {
                    b.HasOne("Medicar_API.Domain.Entities.Schedule", "Schedule")
                        .WithMany("Consultations")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Medicar_API.Domain.Entities.Slot", "Slot")
                        .WithMany("Consultations")
                        .HasForeignKey("SlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");

                    b.Navigation("Slot");
                });

            modelBuilder.Entity("Medicar_API.Domain.Entities.Doctor", b =>
                {
                    b.HasOne("Medicar_API.Domain.Entities.Specialty", "Specialty")
                        .WithOne("Doctor")
                        .HasForeignKey("Medicar_API.Domain.Entities.Doctor", "SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specialty");
                });

            modelBuilder.Entity("Medicar_API.Domain.Entities.Schedule", b =>
                {
                    b.HasOne("Medicar_API.Domain.Entities.Doctor", "Doctor")
                        .WithMany("Schedules")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Medicar_API.Domain.Entities.Slot", b =>
                {
                    b.HasOne("Medicar_API.Domain.Entities.Schedule", "Schedule")
                        .WithMany("Slots")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("Medicar_API.Domain.Entities.Doctor", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("Medicar_API.Domain.Entities.Schedule", b =>
                {
                    b.Navigation("Consultations");

                    b.Navigation("Slots");
                });

            modelBuilder.Entity("Medicar_API.Domain.Entities.Slot", b =>
                {
                    b.Navigation("Consultations");
                });

            modelBuilder.Entity("Medicar_API.Domain.Entities.Specialty", b =>
                {
                    b.Navigation("Doctor")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
