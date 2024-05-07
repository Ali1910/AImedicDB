using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AA_Task.Migrations
{
    public partial class updatequestiontable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_doctors_doctorid",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_times_timeid",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_users_userid",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "appointments");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_userid",
                table: "appointments",
                newName: "IX_appointments_userid");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_timeid",
                table: "appointments",
                newName: "IX_appointments_timeid");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_doctorid",
                table: "appointments",
                newName: "IX_appointments_doctorid");

            migrationBuilder.AddColumn<bool>(
                name: "Answered",
                table: "questions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointments",
                table: "appointments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_doctors_doctorid",
                table: "appointments",
                column: "doctorid",
                principalTable: "doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_times_timeid",
                table: "appointments",
                column: "timeid",
                principalTable: "times",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_users_userid",
                table: "appointments",
                column: "userid",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_doctors_doctorid",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_times_timeid",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_users_userid",
                table: "appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appointments",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "Answered",
                table: "questions");

            migrationBuilder.RenameTable(
                name: "appointments",
                newName: "Appointments");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_userid",
                table: "Appointments",
                newName: "IX_Appointments_userid");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_timeid",
                table: "Appointments",
                newName: "IX_Appointments_timeid");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_doctorid",
                table: "Appointments",
                newName: "IX_Appointments_doctorid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_doctors_doctorid",
                table: "Appointments",
                column: "doctorid",
                principalTable: "doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_times_timeid",
                table: "Appointments",
                column: "timeid",
                principalTable: "times",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_users_userid",
                table: "Appointments",
                column: "userid",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
