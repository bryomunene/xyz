﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using xyz.Data;

#nullable disable

namespace xyz.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241011151812_CreatePaymentsTable")]
    partial class CreatePaymentsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("xyz.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TransactionId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Payments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 100m,
                            CreatedAt = new DateTime(2024, 10, 11, 15, 18, 12, 706, DateTimeKind.Utc).AddTicks(8416),
                            Status = "Pending",
                            TransactionId = "trans123"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 200m,
                            CreatedAt = new DateTime(2024, 10, 11, 15, 18, 12, 706, DateTimeKind.Utc).AddTicks(8428),
                            Status = "Pending",
                            TransactionId = "trans456"
                        });
                });

            modelBuilder.Entity("xyz.Models.PaymentNotification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("TransactionId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PaymentNotifications");
                });

            modelBuilder.Entity("xyz.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsEnrolled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
