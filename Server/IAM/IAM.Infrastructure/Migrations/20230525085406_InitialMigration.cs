using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IAM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Departments_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Personals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    INN = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staffings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    StaffingCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProfessionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staffings_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalId = table.Column<long>(type: "bigint", nullable: false),
                    StaffingId = table.Column<long>(type: "bigint", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Personals_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "Personals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Staffings_StaffingId",
                        column: x => x.StaffingId,
                        principalTable: "Staffings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EntRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    StaffingId = table.Column<long>(type: "bigint", nullable: false),
                    Initiator = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsInherited = table.Column<bool>(type: "bit", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntRoles_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntRoles_Staffings_StaffingId",
                        column: x => x.StaffingId,
                        principalTable: "Staffings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeHasDeltaRoles",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    Initiator = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeHasDeltaRoles", x => new { x.RoleId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_EmployeeHasDeltaRoles_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeHasDeltaRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeHasEntRoles",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    EntRoleId = table.Column<long>(type: "bigint", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeHasEntRoles", x => new { x.EntRoleId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_EmployeeHasEntRoles_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeHasEntRoles_EntRoles_EntRoleId",
                        column: x => x.EntRoleId,
                        principalTable: "EntRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeHasRoles",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    EntRoleId = table.Column<long>(type: "bigint", nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeHasRoles", x => new { x.RoleId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_EmployeeHasRoles_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeHasRoles_EntRoles_EntRoleId",
                        column: x => x.EntRoleId,
                        principalTable: "EntRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeHasRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EntRoleHasRole",
                columns: table => new
                {
                    EntRolesId = table.Column<long>(type: "bigint", nullable: false),
                    RolesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntRoleHasRole", x => new { x.EntRolesId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_EntRoleHasRole_EntRoles_EntRolesId",
                        column: x => x.EntRolesId,
                        principalTable: "EntRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntRoleHasRole_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ParentId",
                table: "Departments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHasDeltaRoles_EmployeeId",
                table: "EmployeeHasDeltaRoles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHasEntRoles_EmployeeId",
                table: "EmployeeHasEntRoles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHasRoles_EmployeeId",
                table: "EmployeeHasRoles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHasRoles_EntRoleId",
                table: "EmployeeHasRoles",
                column: "EntRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PersonalId",
                table: "Employees",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_StaffingId",
                table: "Employees",
                column: "StaffingId");

            migrationBuilder.CreateIndex(
                name: "IX_EntRoleHasRole_RolesId",
                table: "EntRoleHasRole",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_EntRoles_DepartmentId",
                table: "EntRoles",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EntRoles_StaffingId",
                table: "EntRoles",
                column: "StaffingId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name_Type_ExternaId",
                table: "Roles",
                columns: new[] { "Name", "Type", "ExternaId" });

            migrationBuilder.CreateIndex(
                name: "IX_Staffings_DepartmentId",
                table: "Staffings",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeHasDeltaRoles");

            migrationBuilder.DropTable(
                name: "EmployeeHasEntRoles");

            migrationBuilder.DropTable(
                name: "EmployeeHasRoles");

            migrationBuilder.DropTable(
                name: "EntRoleHasRole");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "EntRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Personals");

            migrationBuilder.DropTable(
                name: "Staffings");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
