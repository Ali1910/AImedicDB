using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AA_Task.Migrations
{
    public partial class updatediagnosistable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "mainDiseases",
                table: "diagnosesSummary",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mainDiseases",
                table: "diagnosesSummary");
        }
    }
}
