﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using propertyDetailer.API.Context;

namespace propertyDetailer.API.Migrations
{
    [DbContext(typeof(PropertyDbContext))]
    [Migration("20181030062448_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("propertyDetailer.API.Context.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("County");

                    b.Property<string>("District");

                    b.Property<string>("State");

                    b.Property<string>("Zip");

                    b.Property<string>("ZipPlus4");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("propertyDetailer.API.Context.Financial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("ListPrice");

                    b.Property<decimal>("MonthlyRent");

                    b.HasKey("Id");

                    b.ToTable("Financial");
                });

            modelBuilder.Entity("propertyDetailer.API.Context.Physical", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("YearBuilt");

                    b.HasKey("Id");

                    b.ToTable("Physical");
                });

            modelBuilder.Entity("propertyDetailer.API.Context.PropertyDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<int?>("FinancialId");

                    b.Property<int?>("PhysicalId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("FinancialId");

                    b.HasIndex("PhysicalId");

                    b.ToTable("PropertyDetails");
                });

            modelBuilder.Entity("propertyDetailer.API.Context.PropertyDetails", b =>
                {
                    b.HasOne("propertyDetailer.API.Context.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("propertyDetailer.API.Context.Financial", "Financial")
                        .WithMany()
                        .HasForeignKey("FinancialId");

                    b.HasOne("propertyDetailer.API.Context.Physical", "Physical")
                        .WithMany()
                        .HasForeignKey("PhysicalId");
                });
#pragma warning restore 612, 618
        }
    }
}
