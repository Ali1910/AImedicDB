using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AA_Task.Migrations
{
    public partial class altarSymptomsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "symptom",
                table: "symptoms",
                newName: "symptomInEnglish");

            migrationBuilder.AddColumn<string>(
                name: "symptomInArabic",
                table: "symptoms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "symptomInArabic",
                table: "symptoms");

            migrationBuilder.RenameColumn(
                name: "symptomInEnglish",
                table: "symptoms",
                newName: "symptom");
        }
    }
}
