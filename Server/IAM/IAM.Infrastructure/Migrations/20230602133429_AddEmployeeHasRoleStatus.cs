using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IAM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeHasRoleStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeIdentifier",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeHasRoles",
                table: "EmployeeHasRoles");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "EmployeeHasRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeHasRoles",
                table: "EmployeeHasRoles",
                columns: new[] { "RoleId", "EmployeeId", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeIdentifier",
                table: "Employees",
                column: "EmployeeIdentifier",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeIdentifier",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeHasRoles",
                table: "EmployeeHasRoles");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "EmployeeHasRoles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeHasRoles",
                table: "EmployeeHasRoles",
                columns: new[] { "RoleId", "EmployeeId" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeIdentifier",
                table: "Employees",
                column: "EmployeeIdentifier");
        }
    }
}
