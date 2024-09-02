﻿// <auto-generated />
using System;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240902134140_sensor")]
    partial class sensor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.20");

            modelBuilder.Entity("Entity.Models.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SoldierId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SoldierId")
                        .IsUnique();

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Entity.Models.Position", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(9,6)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(9,6)");

                    b.Property<Guid>("SensorId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SensorId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Entity.Models.Sensor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SoldierId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SoldierId");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("Entity.Models.Soldier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Rank")
                        .HasColumnType("TEXT");

                    b.Property<string>("TrainningInfo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Soldiers");
                });

            modelBuilder.Entity("Entity.Models.Country", b =>
                {
                    b.HasOne("Entity.Models.Soldier", "Soldier")
                        .WithOne("Country")
                        .HasForeignKey("Entity.Models.Country", "SoldierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Soldier");
                });

            modelBuilder.Entity("Entity.Models.Position", b =>
                {
                    b.HasOne("Entity.Models.Sensor", "Sensor")
                        .WithMany("Positions")
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sensor");
                });

            modelBuilder.Entity("Entity.Models.Sensor", b =>
                {
                    b.HasOne("Entity.Models.Soldier", "Soldier")
                        .WithMany("Sensors")
                        .HasForeignKey("SoldierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Soldier");
                });

            modelBuilder.Entity("Entity.Models.Sensor", b =>
                {
                    b.Navigation("Positions");
                });

            modelBuilder.Entity("Entity.Models.Soldier", b =>
                {
                    b.Navigation("Country");

                    b.Navigation("Sensors");
                });
#pragma warning restore 612, 618
        }
    }
}
