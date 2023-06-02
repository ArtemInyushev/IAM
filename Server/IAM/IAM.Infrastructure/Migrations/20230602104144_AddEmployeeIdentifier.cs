using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IAM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeIdentifier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "INN",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "ExternaId",
                table: "Employees");

            migrationBuilder.AddColumn<long>(
                name: "EmployeeIdentifier",
                table: "Employees",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeIdentifier",
                table: "Employees",
                column: "EmployeeIdentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeIdentifier",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeIdentifier",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "INN",
                table: "Personals",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ExternaId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
