using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AA_Task.Migrations
{
    public partial class updatediagnosis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_diagnosesSummary_users_userid",
                table: "diagnosesSummary");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "diagnosesSummary",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_diagnosesSummary_userid",
                table: "diagnosesSummary",
                newName: "IX_diagnosesSummary_UserId");

            migrationBuilder.AddColumn<int>(
                name: "ApponitmentId",
                table: "diagnosesSummary",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "datetime",
                table: "diagnosesSummary",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_diagnosesSummary_ApponitmentId",
                table: "diagnosesSummary",
                column: "ApponitmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_diagnosesSummary_appointments_ApponitmentId",
                table: "diagnosesSummary",
                column: "ApponitmentId",
                principalTable: "appointments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_diagnosesSummary_users_UserId",
                table: "diagnosesSummary",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_diagnosesSummary_appointments_ApponitmentId",
                table: "diagnosesSummary");

            migrationBuilder.DropForeignKey(
                name: "FK_diagnosesSummary_users_UserId",
                table: "diagnosesSummary");

            migrationBuilder.DropIndex(
                name: "IX_diagnosesSummary_ApponitmentId",
                table: "diagnosesSummary");

            migrationBuilder.DropColumn(
                name: "ApponitmentId",
                table: "diagnosesSummary");

            migrationBuilder.DropColumn(
                name: "datetime",
                table: "diagnosesSummary");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "diagnosesSummary",
                newName: "userid");

            migrationBuilder.RenameIndex(
                name: "IX_diagnosesSummary_UserId",
                table: "diagnosesSummary",
                newName: "IX_diagnosesSummary_userid");

            migrationBuilder.AddForeignKey(
                name: "FK_diagnosesSummary_users_userid",
                table: "diagnosesSummary",
                column: "userid",
                principalTable: "users",
                principalColumn: "Id");
        }
    }
}
