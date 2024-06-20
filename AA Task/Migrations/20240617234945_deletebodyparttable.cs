using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AA_Task.Migrations
{
    public partial class deletebodyparttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_symptoms_bodyParts_boypartId",
                table: "symptoms");

            migrationBuilder.DropTable(
                name: "bodyParts");

            migrationBuilder.DropIndex(
                name: "IX_symptoms_boypartId",
                table: "symptoms");

            migrationBuilder.DropColumn(
                name: "boypartId",
                table: "symptoms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "boypartId",
                table: "symptoms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "bodyParts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bodypartInArabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bodypartInEnglis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bodyParts", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_symptoms_boypartId",
                table: "symptoms",
                column: "boypartId");

            migrationBuilder.AddForeignKey(
                name: "FK_symptoms_bodyParts_boypartId",
                table: "symptoms",
                column: "boypartId",
                principalTable: "bodyParts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
