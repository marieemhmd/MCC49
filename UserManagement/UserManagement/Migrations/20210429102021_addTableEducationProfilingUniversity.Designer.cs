﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserManagement.Context;

namespace UserManagement.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210429102021_addTableEducationProfilingUniversity")]
    partial class addTableEducationProfilingUniversity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UserManagement.Models.Account", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NIK");

                    b.ToTable("tb_t_accounts");
                });

            modelBuilder.Entity("UserManagement.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GPA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("tb_m_educations");
                });

            modelBuilder.Entity("UserManagement.Models.Person", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("NIK");

                    b.ToTable("tb_m_persons");
                });

            modelBuilder.Entity("UserManagement.Models.Profiling", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EducationId")
                        .HasColumnType("int");

                    b.HasKey("NIK");

                    b.HasIndex("EducationId");

                    b.ToTable("tb_t_profilings");
                });

            modelBuilder.Entity("UserManagement.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tb_m_universities");
                });

            modelBuilder.Entity("UserManagement.Models.Account", b =>
                {
                    b.HasOne("UserManagement.Models.Person", "Person")
                        .WithOne("Account")
                        .HasForeignKey("UserManagement.Models.Account", "NIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("UserManagement.Models.Education", b =>
                {
                    b.HasOne("UserManagement.Models.University", "University")
                        .WithMany("Education")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("UserManagement.Models.Profiling", b =>
                {
                    b.HasOne("UserManagement.Models.Education", "Education")
                        .WithMany("Profiling")
                        .HasForeignKey("EducationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserManagement.Models.Account", "Account")
                        .WithOne("Profiling")
                        .HasForeignKey("UserManagement.Models.Profiling", "NIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Education");
                });

            modelBuilder.Entity("UserManagement.Models.Account", b =>
                {
                    b.Navigation("Profiling");
                });

            modelBuilder.Entity("UserManagement.Models.Education", b =>
                {
                    b.Navigation("Profiling");
                });

            modelBuilder.Entity("UserManagement.Models.Person", b =>
                {
                    b.Navigation("Account");
                });

            modelBuilder.Entity("UserManagement.Models.University", b =>
                {
                    b.Navigation("Education");
                });
#pragma warning restore 612, 618
        }
    }
}