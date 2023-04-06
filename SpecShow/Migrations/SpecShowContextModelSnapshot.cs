﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpecShow.Data;

#nullable disable

namespace SpecShow.Migrations
{
    [DbContext(typeof(SpecShowContext))]
    partial class SpecShowContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SpecShow.Models.Brand", b =>
                {
                    b.Property<int>("BrandID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandID"));

                    b.Property<string>("LogoURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrandID");

                    b.ToTable("Brand", (string)null);
                });

            modelBuilder.Entity("SpecShow.Models.Favourite", b =>
                {
                    b.Property<int>("FavouritesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FavouritesID"));

                    b.Property<int>("MobileID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("FavouritesID");

                    b.HasIndex("MobileID");

                    b.HasIndex("UserID");

                    b.ToTable("Favourite", (string)null);
                });

            modelBuilder.Entity("SpecShow.Models.Mobile", b =>
                {
                    b.Property<int>("MobileID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MobileID"));

                    b.Property<string>("AmazonUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AntutuScores")
                        .HasColumnType("int");

                    b.Property<string>("AspectRatio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BackCameras")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BatteryCapacity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bluetooth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BrandID")
                        .HasColumnType("int");

                    b.Property<double>("ChargingCapacity")
                        .HasColumnType("float");

                    b.Property<string>("Colors")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlipkartUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrontCamera")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GPU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nanometer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherFeatures")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Processor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResistanceCertificate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resolution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScreenSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScreenType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sensors")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Variants")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("MobileID");

                    b.HasIndex("BrandID");

                    b.ToTable("Mobile", (string)null);
                });

            modelBuilder.Entity("SpecShow.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("SpecShow.Models.Favourite", b =>
                {
                    b.HasOne("SpecShow.Models.Mobile", "Mobile")
                        .WithMany()
                        .HasForeignKey("MobileID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpecShow.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mobile");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SpecShow.Models.Mobile", b =>
                {
                    b.HasOne("SpecShow.Models.Brand", null)
                        .WithMany("Mobiles")
                        .HasForeignKey("BrandID");
                });

            modelBuilder.Entity("SpecShow.Models.Brand", b =>
                {
                    b.Navigation("Mobiles");
                });
#pragma warning restore 612, 618
        }
    }
}