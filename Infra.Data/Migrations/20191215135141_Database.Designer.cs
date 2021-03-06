﻿// <auto-generated />
using System;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191215135141_Database")]
    partial class Database
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Cnpj")
                        .HasMaxLength(14);

                    b.Property<string>("CompanyName")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<Guid>("EntityId");

                    b.Property<string>("FantasyName")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UserType");

                    b.HasKey("Id");

                    b.HasIndex("Cnpj")
                        .IsUnique();

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Domain.Models.Freelancer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Cpf")
                        .HasMaxLength(11);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<Guid>("EntityId");

                    b.Property<string>("Experience");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("Portfolio");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("enum('male', 'female')");

                    b.Property<string>("Skills");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UserType");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.ToTable("Freelancer");
                });

            modelBuilder.Entity("Domain.Models.HomeOffice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Cpf")
                        .HasMaxLength(11);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<Guid>("EntityId");

                    b.Property<string>("Experience");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("Portfolio");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("enum('male', 'female')");

                    b.Property<string>("Skills");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UserType");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.ToTable("HomeOffice");
                });

            modelBuilder.Entity("Domain.Models.PhysicalPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Cpf")
                        .HasMaxLength(11);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<Guid>("EntityId");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("enum('male', 'female')");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UserType");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.ToTable("PhysicalPerson");
                });
#pragma warning restore 612, 618
        }
    }
}
