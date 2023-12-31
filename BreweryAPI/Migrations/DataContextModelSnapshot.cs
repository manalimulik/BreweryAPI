﻿// <auto-generated />
using BreweryAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BreweryAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.7");

            modelBuilder.Entity("BreweryAPI.Models.Bar", b =>
                {
                    b.Property<int>("BarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BarAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BarName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BarId");

                    b.ToTable("tblBar");
                });

            modelBuilder.Entity("BreweryAPI.Models.BarAndBeerInfo", b =>
                {
                    b.Property<int>("BarAndBeerInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BarId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BeerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BarAndBeerInfoId");

                    b.ToTable("tblBarAndBeerInfo");
                });

            modelBuilder.Entity("BreweryAPI.Models.Beer", b =>
                {
                    b.Property<int>("BeerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BeerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PercentageAlchoholByVolume")
                        .HasColumnType("TEXT");

                    b.HasKey("BeerId");

                    b.ToTable("tblBeer");
                });

            modelBuilder.Entity("BreweryAPI.Models.Brewery", b =>
                {
                    b.Property<int>("BreweryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BreweryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BreweryId");

                    b.ToTable("tblBrewery");
                });

            modelBuilder.Entity("BreweryAPI.Models.BreweryAndBeerInfo", b =>
                {
                    b.Property<int>("BreweryAndBeerInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BeerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BreweryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BreweryAndBeerInfoId");

                    b.ToTable("tblBreweryAndBeerInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
