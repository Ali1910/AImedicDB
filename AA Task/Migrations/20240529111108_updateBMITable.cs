using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AA_Task.Migrations
{
    public partial class updateBMITable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "day",
                table: "BMI",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "hour",
                table: "BMI",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "minute",
                table: "BMI",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "month",
                table: "BMI",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "year",
                table: "BMI",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "day",
                table: "BMI");

            migrationBuilder.DropColumn(
                name: "hour",
                table: "BMI");

            migrationBuilder.DropColumn(
                name: "minute",
                table: "BMI");

            migrationBuilder.DropColumn(
                name: "month",
                table: "BMI");

            migrationBuilder.DropColumn(
                name: "year",
                table: "BMI");
        }
    }
}
