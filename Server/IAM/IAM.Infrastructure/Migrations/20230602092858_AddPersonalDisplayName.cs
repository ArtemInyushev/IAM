using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IAM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonalDisplayName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "Personals");

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Personals",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Personals");

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "Personals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
