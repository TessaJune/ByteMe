using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trainor.Storage.Migrations
{
    public partial class NotMappedCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Resources",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SubjectTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ResourceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectTags_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTags_ResourceId",
                table: "SubjectTags",
                column: "ResourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectTags");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Resources",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
