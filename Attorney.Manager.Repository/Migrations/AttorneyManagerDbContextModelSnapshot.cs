﻿// <auto-generated />
using System;
using Attorney.Manager.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Attorney.Manager.Repository.Migrations
{
    [DbContext(typeof(AttorneyManagerDbContext))]
    partial class AttorneyManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Attorney.Manager.Domain.Addresses.CommercialAdress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("commercial_id");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnName("city")
                        .HasColumnType("nvarchar(125)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnName("country")
                        .HasColumnType("nvarchar(125)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnName("postal_code")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnName("state")
                        .HasColumnType("nvarchar(125)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnName("street_name")
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("commercial_adress");
                });

            modelBuilder.Entity("Attorney.Manager.Domain.Registration.Attorney", b =>
                {
                    b.Property<int>("AttorneyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("attoreny_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(125)");

                    b.Property<int>("commercial_adress_id");

                    b.HasKey("AttorneyId");

                    b.HasIndex("commercial_adress_id");

                    b.ToTable("attorney");
                });

            modelBuilder.Entity("Attorney.Manager.Domain.Registration.Seniority", b =>
                {
                    b.Property<int>("SeniorityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("seniority_id");

                    b.Property<int>("SeniorityType")
                        .HasColumnName("seniority")
                        .HasColumnType("INT");

                    b.Property<int?>("attorney_id");

                    b.HasKey("SeniorityId");

                    b.HasIndex("attorney_id");

                    b.ToTable("Seniority");
                });

            modelBuilder.Entity("Attorney.Manager.Domain.Registration.Attorney", b =>
                {
                    b.HasOne("Attorney.Manager.Domain.Addresses.CommercialAdress", "CommercialAdress")
                        .WithMany()
                        .HasForeignKey("commercial_adress_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Attorney.Manager.Domain.Registration.Seniority", b =>
                {
                    b.HasOne("Attorney.Manager.Domain.Registration.Attorney", "Attorney")
                        .WithMany("Seniority")
                        .HasForeignKey("attorney_id");
                });
#pragma warning restore 612, 618
        }
    }
}
