// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Saitynai_Delivery_System1.Data;

#nullable disable

namespace Saitynai_Delivery_System1.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220911081255_Full_V2")]
    partial class Full_V2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Saitynai_Delivery_System1.Models.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("RecipientId")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("Saitynai_Delivery_System1.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Wage")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Saitynai_Delivery_System1.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DriverId")
                        .HasColumnType("int");

                    b.Property<int>("MaxPayload")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegNumbers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DriverId")
                        .IsUnique()
                        .HasFilter("[DriverId] IS NOT NULL");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Saitynai_Delivery_System1.Models.Package", b =>
                {
                    b.HasOne("Saitynai_Delivery_System1.Models.User", "Recipient")
                        .WithMany("Packages")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Saitynai_Delivery_System1.Models.Vehicle", "Vehicle")
                        .WithMany("AssignedPackages")
                        .HasForeignKey("VehicleId");

                    b.Navigation("Recipient");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Saitynai_Delivery_System1.Models.Vehicle", b =>
                {
                    b.HasOne("Saitynai_Delivery_System1.Models.User", "Driver")
                        .WithOne("Vehicle")
                        .HasForeignKey("Saitynai_Delivery_System1.Models.Vehicle", "DriverId");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("Saitynai_Delivery_System1.Models.User", b =>
                {
                    b.Navigation("Packages");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Saitynai_Delivery_System1.Models.Vehicle", b =>
                {
                    b.Navigation("AssignedPackages");
                });
#pragma warning restore 612, 618
        }
    }
}
