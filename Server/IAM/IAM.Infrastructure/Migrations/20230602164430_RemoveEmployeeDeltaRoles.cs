using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IAM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEmployeeDeltaRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeHasDeltaRoles");

            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "EntRoles");

            migrationBuilder.DropColumn(
                name: "DateStart",
                table: "EntRoles");

            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "EmployeeHasRoles");

            migrationBuilder.DropColumn(
                name: "DateStart",
                table: "EmployeeHasRoles");

            migrationBuilder.AddColumn<string>(
                name: "Initiator",
                table: "EmployeeHasRoles",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Initiator",
                table: "EmployeeHasRoles");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "EntRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateStart",
                table: "EntRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "EmployeeHasRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateStart",
                table: "EmployeeHasRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "EmployeeHasDeltaRoles",
                columns: table => new
                {
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Initiator = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHasDeltaRoles_EmployeeId",
                table: "EmployeeHasDeltaRoles",
                column: "EmployeeId");
        }
    }
}
