using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AA_Task.Migrations
{
    public partial class addingnewtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "times",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    month = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    day = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_times", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: false),
                    doctorid = table.Column<int>(type: "int", nullable: false),
                    timeid = table.Column<int>(type: "int", nullable: false),
                    appointmentTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Done = table.Column<bool>(type: "bit", nullable: false),
                    Canceled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_doctors_doctorid",
                        column: x => x.doctorid,
                        principalTable: "doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_times_timeid",
                        column: x => x.timeid,
                        principalTable: "times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "doctorTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    datetime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empty = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctorTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_doctorTimes_doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_doctorTimes_times_TimeId",
                        column: x => x.TimeId,
                        principalTable: "times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userKey = table.Column<int>(type: "int", nullable: false),
                    Timekey = table.Column<int>(type: "int", nullable: false),
                    empty = table.Column<bool>(type: "bit", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userTimes_times_Timekey",
                        column: x => x.Timekey,
                        principalTable: "times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userTimes_users_userKey",
                        column: x => x.userKey,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_doctorid",
                table: "Appointments",
                column: "doctorid");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_timeid",
                table: "Appointments",
                column: "timeid");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_userid",
                table: "Appointments",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_doctorTimes_DoctorId",
                table: "doctorTimes",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_doctorTimes_TimeId",
                table: "doctorTimes",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_userTimes_Timekey",
                table: "userTimes",
                column: "Timekey");

            migrationBuilder.CreateIndex(
                name: "IX_userTimes_userKey",
                table: "userTimes",
                column: "userKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "doctorTimes");

            migrationBuilder.DropTable(
                name: "userTimes");

            migrationBuilder.DropTable(
                name: "times");
        }
    }
}
