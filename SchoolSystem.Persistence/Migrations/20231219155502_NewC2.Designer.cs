﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolSystem.Persistence.Context;

#nullable disable

namespace SchoolSystem.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231219155502_NewC2")]
    partial class NewC2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SchoolSystem.Domain.Entites.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("InstructorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("SchoolSystem.Domain.Entites.Enrollment", b =>
                {
                    b.Property<int>("Student_Id")
                        .HasColumnType("int");

                    b.Property<int>("Course_ID")
                        .HasColumnType("int");

                    b.HasKey("Student_Id", "Course_ID");

                    b.HasIndex("Course_ID");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("SchoolSystem.Domain.Entites.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<double>("GPA")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SchoolSystem.Domain.Entites.Enrollment", b =>
                {
                    b.HasOne("SchoolSystem.Domain.Entites.Course", "Courses")
                        .WithMany("Enrollments")
                        .HasForeignKey("Course_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystem.Domain.Entites.Student", "Students")
                        .WithMany("Enrollments")
                        .HasForeignKey("Student_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Courses");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("SchoolSystem.Domain.Entites.Course", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("SchoolSystem.Domain.Entites.Student", b =>
                {
                    b.Navigation("Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
