using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AA_Task.Migrations
{
    public partial class addedratedtoappointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "rated",
                table: "appointments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rated",
                table: "appointments");
        }
    }
}
