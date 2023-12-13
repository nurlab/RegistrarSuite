﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistrarSuite.Data.DataContext;

#nullable disable

namespace RegistrarSuite.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231209142423_update1292023")]
    partial class update1292023
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("RegistrarSuite.Data.Models.MetadataSchema.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CallingCode")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrencyCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Flag")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Latitude")
                        .HasColumnType("TEXT");

                    b.Property<string>("Longitude")
                        .HasColumnType("TEXT");

                    b.Property<string>("NativeName")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Population")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Countries", "Metadata");
                });

            modelBuilder.Entity("RegistrarSuite.Data.Models.StudentSchema.FamilyMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("nationalityCode")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Relationship")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("nationalityCode");

                    b.HasIndex("StudentId");

                    b.ToTable("FamilyMembers", "Student");
                });

            modelBuilder.Entity("RegistrarSuite.Data.Models.StudentSchema.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("nationalityCode")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("nationalityCode");

                    b.ToTable("Students", "Student");
                });

            modelBuilder.Entity("RegistrarSuite.Data.Models.StudentSchema.FamilyMember", b =>
                {
                    b.HasOne("RegistrarSuite.Data.Models.MetadataSchema.Country", "Nationality")
                        .WithMany()
                        .HasForeignKey("nationalityCode");

                    b.HasOne("RegistrarSuite.Data.Models.StudentSchema.Student", "Student")
                        .WithMany("FamilyMembers")
                        .HasForeignKey("StudentId");

                    b.Navigation("Nationality");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("RegistrarSuite.Data.Models.StudentSchema.Student", b =>
                {
                    b.HasOne("RegistrarSuite.Data.Models.MetadataSchema.Country", "Nationality")
                        .WithMany()
                        .HasForeignKey("nationalityCode");

                    b.Navigation("Nationality");
                });

            modelBuilder.Entity("RegistrarSuite.Data.Models.StudentSchema.Student", b =>
                {
                    b.Navigation("FamilyMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
