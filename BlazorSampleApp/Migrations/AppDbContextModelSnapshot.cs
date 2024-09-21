﻿// <auto-generated />
using System;
using BlazorSampleApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorSampleApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("BlazorSampleApp.Models.GameDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("GenreId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("GameDetails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreId = "1",
                            Name = "Call of Duty",
                            Price = 4999.98m,
                            ReleaseDate = new DateOnly(2020, 2, 26)
                        },
                        new
                        {
                            Id = 2,
                            GenreId = "5",
                            Name = "8 ball poll",
                            Price = 68.90m,
                            ReleaseDate = new DateOnly(2010, 4, 26)
                        },
                        new
                        {
                            Id = 3,
                            GenreId = "4",
                            Name = "Subway Surface",
                            Price = 500m,
                            ReleaseDate = new DateOnly(2013, 7, 15)
                        });
                });

            modelBuilder.Entity("BlazorSampleApp.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genre");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fighting"
                        },
                        new
                        {
                            Id = 2,
                            Name = "RolePlaying"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sports"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Racing"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Kids and Family"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
