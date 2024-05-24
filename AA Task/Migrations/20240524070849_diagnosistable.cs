using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AA_Task.Migrations
{
    public partial class diagnosistable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_diagnosis_doctors_doctorId",
                table: "diagnosis");

            migrationBuilder.DropForeignKey(
                name: "FK_diagnosis_users_userid",
                table: "diagnosis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_diagnosis",
                table: "diagnosis");

            migrationBuilder.RenameTable(
                name: "diagnosis",
                newName: "diagnosesSummary");

            migrationBuilder.RenameIndex(
                name: "IX_diagnosis_userid",
                table: "diagnosesSummary",
                newName: "IX_diagnosesSummary_userid");

            migrationBuilder.RenameIndex(
                name: "IX_diagnosis_doctorId",
                table: "diagnosesSummary",
                newName: "IX_diagnosesSummary_doctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_diagnosesSummary",
                table: "diagnosesSummary",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_diagnosesSummary_doctors_doctorId",
                table: "diagnosesSummary",
                column: "doctorId",
                principalTable: "doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_diagnosesSummary_users_userid",
                table: "diagnosesSummary",
                column: "userid",
                principalTable: "users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_diagnosesSummary_doctors_doctorId",
                table: "diagnosesSummary");

            migrationBuilder.DropForeignKey(
                name: "FK_diagnosesSummary_users_userid",
                table: "diagnosesSummary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_diagnosesSummary",
                table: "diagnosesSummary");

            migrationBuilder.RenameTable(
                name: "diagnosesSummary",
                newName: "diagnosis");

            migrationBuilder.RenameIndex(
                name: "IX_diagnosesSummary_userid",
                table: "diagnosis",
                newName: "IX_diagnosis_userid");

            migrationBuilder.RenameIndex(
                name: "IX_diagnosesSummary_doctorId",
                table: "diagnosis",
                newName: "IX_diagnosis_doctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_diagnosis",
                table: "diagnosis",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_diagnosis_doctors_doctorId",
                table: "diagnosis",
                column: "doctorId",
                principalTable: "doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_diagnosis_users_userid",
                table: "diagnosis",
                column: "userid",
                principalTable: "users",
                principalColumn: "Id");
        }
    }
}
