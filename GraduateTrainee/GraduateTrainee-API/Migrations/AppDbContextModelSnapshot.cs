﻿// <auto-generated />
using System;
using GraduateTraineeEnrollmentApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GraduateTraineeEnrollmentApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GraduateTraineeEnrollmentApi.Models.Degree", b =>
                {
                    b.Property<int>("DegreeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DegreeId"), 1L, 1);

                    b.Property<string>("DegreeDescription")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("DegreeName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("DegreeId");

                    b.ToTable("Degree");
                });

            modelBuilder.Entity("GraduateTraineeEnrollmentApi.Models.GraduateTrainees", b =>
                {
                    b.Property<int>("GraduateTraineeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GraduateTraineeId"), 1L, 1);

                    b.Property<decimal?>("Ai")
                        .HasColumnType("decimal(18,0)")
                        .HasColumnName("AI");

                    b.Property<decimal?>("BusinessAnalysis")
                        .HasColumnType("decimal(18,0)");

                    b.Property<DateTime>("DateOfApplication")
                        .HasColumnType("date");

                    b.Property<int?>("DegreeId")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)");

                    b.Property<string>("Image")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<bool?>("IsAdmisisonConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLastSemesterPending")
                        .HasColumnType("bit");

                    b.Property<decimal?>("MachineLearning")
                        .HasColumnType("decimal(18,0)");

                    b.Property<decimal?>("Percentages")
                        .HasColumnType("decimal(18,0)");

                    b.Property<decimal?>("Phyton")
                        .HasColumnType("decimal(18,0)");

                    b.Property<decimal?>("Practical")
                        .HasColumnType("decimal(18,0)");

                    b.Property<int?>("StreamId")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalMarks")
                        .HasColumnType("decimal(18,0)");

                    b.Property<string>("TraineeEmail")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("TraineeName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("UniversityName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.HasKey("GraduateTraineeId")
                        .HasName("PK__Graduate__D5A8F04CC1671608");

                    b.HasIndex("DegreeId");

                    b.HasIndex("StreamId");

                    b.ToTable("GraduateTrainees");
                });

            modelBuilder.Entity("GraduateTraineeEnrollmentApi.Models.Streams", b =>
                {
                    b.Property<int>("StreamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StreamId"), 1L, 1);

                    b.Property<int?>("DegreeId")
                        .HasColumnType("int");

                    b.Property<string>("StreamDescription")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("StreamName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("StreamId")
                        .HasName("PK__Streams__07C87A9261B6B4F7");

                    b.HasIndex("DegreeId");

                    b.ToTable("Streams");
                });

            modelBuilder.Entity("GraduateTraineeEnrollmentApi.Models.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userId"), 1L, 1);

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("LoginId")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("userId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GraduateTraineeEnrollmentApi.Models.GraduateTrainees", b =>
                {
                    b.HasOne("GraduateTraineeEnrollmentApi.Models.Degree", "Degree")
                        .WithMany("GraduateTrainees")
                        .HasForeignKey("DegreeId")
                        .HasConstraintName("FK__GraduateT__Degre__3B75D760");

                    b.HasOne("GraduateTraineeEnrollmentApi.Models.Streams", "Stream")
                        .WithMany("GraduateTrainees")
                        .HasForeignKey("StreamId")
                        .HasConstraintName("FK__GraduateT__Strea__3C69FB99");

                    b.Navigation("Degree");

                    b.Navigation("Stream");
                });

            modelBuilder.Entity("GraduateTraineeEnrollmentApi.Models.Streams", b =>
                {
                    b.HasOne("GraduateTraineeEnrollmentApi.Models.Degree", "Degree")
                        .WithMany("Streams")
                        .HasForeignKey("DegreeId")
                        .HasConstraintName("FK__Streams__DegreeI__3D5E1FD2");

                    b.Navigation("Degree");
                });

            modelBuilder.Entity("GraduateTraineeEnrollmentApi.Models.Degree", b =>
                {
                    b.Navigation("GraduateTrainees");

                    b.Navigation("Streams");
                });

            modelBuilder.Entity("GraduateTraineeEnrollmentApi.Models.Streams", b =>
                {
                    b.Navigation("GraduateTrainees");
                });
#pragma warning restore 612, 618
        }
    }
}
