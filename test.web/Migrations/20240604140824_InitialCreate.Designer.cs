﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using test.web.Models;

#nullable disable

namespace test.web.Migrations
{
    [DbContext(typeof(EmployeeDb))]
    [Migration("20240604140824_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("test.web.Models.EmployeeModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("hobby")
                        .HasColumnType("TEXT");

                    b.Property<string>("mail")
                        .HasColumnType("TEXT");

                    b.Property<string>("phone_no")
                        .HasColumnType("TEXT");

                    b.Property<string>("skill_set")
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("EmployeeModels");
                });
#pragma warning restore 612, 618
        }
    }
}
