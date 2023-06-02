﻿// <auto-generated />
using System;
using IAM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IAM.Infrastructure.Migrations
{
    [DbContext(typeof(IamDbContext))]
    partial class IamDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntRoleHasRole", b =>
                {
                    b.Property<long>("EntRolesId")
                        .HasColumnType("bigint");

                    b.Property<long>("RolesId")
                        .HasColumnType("bigint");

                    b.HasKey("EntRolesId", "RolesId");

                    b.HasIndex("RolesId");

                    b.ToTable("EntRoleHasRole");
                });

            modelBuilder.Entity("IAM.Core.Models.Department", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("DepartmentCode")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentCode")
                        .IsUnique();

                    b.HasIndex("ParentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("IAM.Core.Models.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AccountName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("EmployeeIdentifier")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<long>("PersonalId")
                        .HasColumnType("bigint");

                    b.Property<long>("StaffingId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeIdentifier")
                        .IsUnique();

                    b.HasIndex("PersonalId");

                    b.HasIndex("StaffingId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("IAM.Core.Models.EmployeeHasDeltaRole", b =>
                {
                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Initiator")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RoleId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeHasDeltaRoles");
                });

            modelBuilder.Entity("IAM.Core.Models.EmployeeHasEntRole", b =>
                {
                    b.Property<long>("EntRoleId")
                        .HasColumnType("bigint");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.HasKey("EntRoleId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeHasEntRoles");
                });

            modelBuilder.Entity("IAM.Core.Models.EmployeeHasRole", b =>
                {
                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<long?>("EntRoleId")
                        .HasColumnType("bigint");

                    b.HasKey("RoleId", "EmployeeId", "Status");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("EntRoleId");

                    b.ToTable("EmployeeHasRoles");
                });

            modelBuilder.Entity("IAM.Core.Models.EntRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<long>("DepartmentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Initiator")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsInherited")
                        .HasColumnType("bit");

                    b.Property<long>("StaffingId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("StaffingId");

                    b.ToTable("EntRoles");
                });

            modelBuilder.Entity("IAM.Core.Models.Personal", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("DisplayName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Personals");
                });

            modelBuilder.Entity("IAM.Core.Models.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<Guid>("ExternaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name", "Type", "ExternaId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("IAM.Core.Models.Staffing", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("DepartmentId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProfessionName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("StaffingCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("StaffingCode")
                        .IsUnique();

                    b.ToTable("Staffings");
                });

            modelBuilder.Entity("EntRoleHasRole", b =>
                {
                    b.HasOne("IAM.Core.Models.EntRole", null)
                        .WithMany()
                        .HasForeignKey("EntRolesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IAM.Core.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("IAM.Core.Models.Department", b =>
                {
                    b.HasOne("IAM.Core.Models.Department", "ParentDepartment")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("ParentDepartment");
                });

            modelBuilder.Entity("IAM.Core.Models.Employee", b =>
                {
                    b.HasOne("IAM.Core.Models.Personal", "Personal")
                        .WithMany()
                        .HasForeignKey("PersonalId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("IAM.Core.Models.Staffing", "Staffing")
                        .WithMany("Employees")
                        .HasForeignKey("StaffingId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Personal");

                    b.Navigation("Staffing");
                });

            modelBuilder.Entity("IAM.Core.Models.EmployeeHasDeltaRole", b =>
                {
                    b.HasOne("IAM.Core.Models.Employee", "Employee")
                        .WithMany("EmployeeHasDeltaRoles")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("IAM.Core.Models.Role", "Role")
                        .WithMany("EmployeeHasDeltaRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("IAM.Core.Models.EmployeeHasEntRole", b =>
                {
                    b.HasOne("IAM.Core.Models.Employee", "Employee")
                        .WithMany("EmployeeHasEntRoles")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("IAM.Core.Models.EntRole", "EntRole")
                        .WithMany("EmployeeHasEntRoles")
                        .HasForeignKey("EntRoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("EntRole");
                });

            modelBuilder.Entity("IAM.Core.Models.EmployeeHasRole", b =>
                {
                    b.HasOne("IAM.Core.Models.Employee", "Employee")
                        .WithMany("EmployeeHasRoles")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("IAM.Core.Models.EntRole", "EntRole")
                        .WithMany("EmployeeHasRoles")
                        .HasForeignKey("EntRoleId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("IAM.Core.Models.Role", "Role")
                        .WithMany("EmployeeHasRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("EntRole");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("IAM.Core.Models.EntRole", b =>
                {
                    b.HasOne("IAM.Core.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IAM.Core.Models.Staffing", "Staffing")
                        .WithMany("EntRoles")
                        .HasForeignKey("StaffingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Staffing");
                });

            modelBuilder.Entity("IAM.Core.Models.Staffing", b =>
                {
                    b.HasOne("IAM.Core.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("IAM.Core.Models.Employee", b =>
                {
                    b.Navigation("EmployeeHasDeltaRoles");

                    b.Navigation("EmployeeHasEntRoles");

                    b.Navigation("EmployeeHasRoles");
                });

            modelBuilder.Entity("IAM.Core.Models.EntRole", b =>
                {
                    b.Navigation("EmployeeHasEntRoles");

                    b.Navigation("EmployeeHasRoles");
                });

            modelBuilder.Entity("IAM.Core.Models.Role", b =>
                {
                    b.Navigation("EmployeeHasDeltaRoles");

                    b.Navigation("EmployeeHasRoles");
                });

            modelBuilder.Entity("IAM.Core.Models.Staffing", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("EntRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
