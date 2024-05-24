using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AA_Task.Migrations
{
    public partial class updatedoctortableaddrating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "doctors",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "location",
                table: "doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ratingAndComments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rating = table.Column<float>(type: "real", nullable: false),
                    doctorId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    appointmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ratingAndComments", x => x.id);
                    table.ForeignKey(
                        name: "FK_ratingAndComments_appointments_appointmentId",
                        column: x => x.appointmentId,
                        principalTable: "appointments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ratingAndComments_doctors_doctorId",
                        column: x => x.doctorId,
                        principalTable: "doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ratingAndComments_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ratingAndComments_appointmentId",
                table: "ratingAndComments",
                column: "appointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ratingAndComments_doctorId",
                table: "ratingAndComments",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_ratingAndComments_UserId",
                table: "ratingAndComments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ratingAndComments");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "location",
                table: "doctors");
        }
    }
}
