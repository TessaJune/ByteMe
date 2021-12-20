using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trainor.Storage.Migrations
{
    public partial class SeedMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Types",
                table: "Resources",
                newName: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Resources",
                newName: "Types");
        }
    }
}
