using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AA_Task.Migrations
{
    public partial class alternbodypartTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "bodypart",
                table: "bodyParts",
                newName: "bodypartInEnglis");

            migrationBuilder.AddColumn<string>(
                name: "bodypartInArabic",
                table: "bodyParts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bodypartInArabic",
                table: "bodyParts");

            migrationBuilder.RenameColumn(
                name: "bodypartInEnglis",
                table: "bodyParts",
                newName: "bodypart");
        }
    }
}
