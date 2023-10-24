﻿// <auto-generated />
using System;
using Employee.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Employee.Infrastructure.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20231024073307_updatemigration")]
    partial class updatemigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Employee.Domain.Entities.EmployeeDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Employee.Domain.Entities.EmployeePayment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("AmountPayed")
                        .HasColumnType("real");

                    b.Property<long>("EmployeeDetailId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeDetailId");

                    b.ToTable("EmployeePayment");
                });

            modelBuilder.Entity("Employee.Domain.Entities.EmployeeSalary", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("EmployeeDetailId")
                        .HasColumnType("bigint");

                    b.Property<float>("Hours")
                        .HasColumnType("real");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.Property<float>("SalaryPerHour")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeDetailId");

                    b.ToTable("EmployeeSalary");
                });

            modelBuilder.Entity("Employee.Domain.Entities.EmployeePayment", b =>
                {
                    b.HasOne("Employee.Domain.Entities.EmployeeDetail", "EmployeeDetail")
                        .WithMany("EmployeePayment")
                        .HasForeignKey("EmployeeDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeDetail");
                });

            modelBuilder.Entity("Employee.Domain.Entities.EmployeeSalary", b =>
                {
                    b.HasOne("Employee.Domain.Entities.EmployeeDetail", "EmployeeDetail")
                        .WithMany("EmployeeSalary")
                        .HasForeignKey("EmployeeDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeDetail");
                });

            modelBuilder.Entity("Employee.Domain.Entities.EmployeeDetail", b =>
                {
                    b.Navigation("EmployeePayment");

                    b.Navigation("EmployeeSalary");
                });
#pragma warning restore 612, 618
        }
    }
}