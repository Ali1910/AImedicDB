using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AA_Task.Migrations
{
    public partial class xx1253 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ratingAndComments_appointments_appointmentId",
                table: "ratingAndComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ratingAndComments_doctors_doctorId",
                table: "ratingAndComments");

            migrationBuilder.RenameColumn(
                name: "rating",
                table: "ratingAndComments",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "doctorId",
                table: "ratingAndComments",
                newName: "DoctorId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ratingAndComments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "comment",
                table: "ratingAndComments",
                newName: "commment");

            migrationBuilder.RenameColumn(
                name: "appointmentId",
                table: "ratingAndComments",
                newName: "ApponintmetId");

            migrationBuilder.RenameIndex(
                name: "IX_ratingAndComments_doctorId",
                table: "ratingAndComments",
                newName: "IX_ratingAndComments_DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_ratingAndComments_appointmentId",
                table: "ratingAndComments",
                newName: "IX_ratingAndComments_ApponintmetId");

            migrationBuilder.AddForeignKey(
                name: "FK_ratingAndComments_appointments_ApponintmetId",
                table: "ratingAndComments",
                column: "ApponintmetId",
                principalTable: "appointments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ratingAndComments_doctors_DoctorId",
                table: "ratingAndComments",
                column: "DoctorId",
                principalTable: "doctors",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ratingAndComments_appointments_ApponintmetId",
                table: "ratingAndComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ratingAndComments_doctors_DoctorId",
                table: "ratingAndComments");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "ratingAndComments",
                newName: "rating");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "ratingAndComments",
                newName: "doctorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ratingAndComments",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "commment",
                table: "ratingAndComments",
                newName: "comment");

            migrationBuilder.RenameColumn(
                name: "ApponintmetId",
                table: "ratingAndComments",
                newName: "appointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_ratingAndComments_DoctorId",
                table: "ratingAndComments",
                newName: "IX_ratingAndComments_doctorId");

            migrationBuilder.RenameIndex(
                name: "IX_ratingAndComments_ApponintmetId",
                table: "ratingAndComments",
                newName: "IX_ratingAndComments_appointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ratingAndComments_appointments_appointmentId",
                table: "ratingAndComments",
                column: "appointmentId",
                principalTable: "appointments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ratingAndComments_doctors_doctorId",
                table: "ratingAndComments",
                column: "doctorId",
                principalTable: "doctors",
                principalColumn: "Id");
        }
    }
}
