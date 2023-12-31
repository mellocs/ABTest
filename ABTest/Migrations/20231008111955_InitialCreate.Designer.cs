﻿// <auto-generated />
using ABTest.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ABTest.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231008111955_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ABTest.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DeviceToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("ABTest.Models.DeviceExperiment", b =>
                {
                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<int>("ExperimentId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeviceId", "ExperimentId");

                    b.HasIndex("ExperimentId");

                    b.ToTable("DeviceExperiments");
                });

            modelBuilder.Entity("ABTest.Models.Experiment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Experiments");
                });

            modelBuilder.Entity("ABTest.Models.DeviceExperiment", b =>
                {
                    b.HasOne("ABTest.Models.Device", "Device")
                        .WithMany("DeviceExperiments")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ABTest.Models.Experiment", "Experiment")
                        .WithMany("DeviceExperiments")
                        .HasForeignKey("ExperimentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("Experiment");
                });

            modelBuilder.Entity("ABTest.Models.Device", b =>
                {
                    b.Navigation("DeviceExperiments");
                });

            modelBuilder.Entity("ABTest.Models.Experiment", b =>
                {
                    b.Navigation("DeviceExperiments");
                });
#pragma warning restore 612, 618
        }
    }
}
