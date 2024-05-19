using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AA_Task.Migrations
{
    public partial class addSymptomsTableAndBodyPartTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bodyParts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bodypart = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bodyParts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "symptoms",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    symptom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    boypartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_symptoms", x => x.id);
                    table.ForeignKey(
                        name: "FK_symptoms_bodyParts_boypartId",
                        column: x => x.boypartId,
                        principalTable: "bodyParts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_symptoms_boypartId",
                table: "symptoms",
                column: "boypartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "symptoms");

            migrationBuilder.DropTable(
                name: "bodyParts");
        }
    }
}
