using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IAM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameExternaId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeHasRoles",
                table: "EmployeeHasRoles");

            migrationBuilder.RenameColumn(
                name: "ExternaId",
                table: "Roles",
                newName: "ExternalId");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_Name_Type_ExternaId",
                table: "Roles",
                newName: "IX_Roles_Name_Type_ExternalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeHasRoles",
                table: "EmployeeHasRoles",
                columns: new[] { "RoleId", "EmployeeId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeHasRoles",
                table: "EmployeeHasRoles");

            migrationBuilder.RenameColumn(
                name: "ExternalId",
                table: "Roles",
                newName: "ExternaId");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_Name_Type_ExternalId",
                table: "Roles",
                newName: "IX_Roles_Name_Type_ExternaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeHasRoles",
                table: "EmployeeHasRoles",
                columns: new[] { "RoleId", "EmployeeId", "Status" });
        }
    }
}
