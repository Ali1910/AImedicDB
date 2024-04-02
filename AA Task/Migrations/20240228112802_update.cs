using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AA_Task.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doctors_specialties_doctorspecialty",
                table: "doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_medicationWarningJoins_medications_MedicationName",
                table: "medicationWarningJoins");

            migrationBuilder.DropForeignKey(
                name: "FK_medicationWarningJoins_warnings_WarningName",
                table: "medicationWarningJoins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_warnings",
                table: "warnings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_specialties",
                table: "specialties");

            migrationBuilder.DropIndex(
                name: "IX_medicationWarningJoins_MedicationName",
                table: "medicationWarningJoins");

            migrationBuilder.DropIndex(
                name: "IX_medicationWarningJoins_WarningName",
                table: "medicationWarningJoins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_medications",
                table: "medications");

            migrationBuilder.DropIndex(
                name: "IX_doctors_doctorspecialty",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "MedicationName",
                table: "medicationWarningJoins");

            migrationBuilder.DropColumn(
                name: "WarningName",
                table: "medicationWarningJoins");

            migrationBuilder.DropColumn(
                name: "doctorspecialty",
                table: "doctors");

            migrationBuilder.AlterColumn<string>(
                name: "WarningName",
                table: "warnings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "warnings",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "specialties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "specialties",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MedicationId",
                table: "medicationWarningJoins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WarningId",
                table: "medicationWarningJoins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "medications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "medications",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "doctorspecialtyId",
                table: "doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_warnings",
                table: "warnings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_specialties",
                table: "specialties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_medications",
                table: "medications",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_medicationWarningJoins_MedicationId",
                table: "medicationWarningJoins",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_medicationWarningJoins_WarningId",
                table: "medicationWarningJoins",
                column: "WarningId");

            migrationBuilder.CreateIndex(
                name: "IX_doctors_doctorspecialtyId",
                table: "doctors",
                column: "doctorspecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_doctors_specialties_doctorspecialtyId",
                table: "doctors",
                column: "doctorspecialtyId",
                principalTable: "specialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_medicationWarningJoins_medications_MedicationId",
                table: "medicationWarningJoins",
                column: "MedicationId",
                principalTable: "medications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_medicationWarningJoins_warnings_WarningId",
                table: "medicationWarningJoins",
                column: "WarningId",
                principalTable: "warnings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doctors_specialties_doctorspecialtyId",
                table: "doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_medicationWarningJoins_medications_MedicationId",
                table: "medicationWarningJoins");

            migrationBuilder.DropForeignKey(
                name: "FK_medicationWarningJoins_warnings_WarningId",
                table: "medicationWarningJoins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_warnings",
                table: "warnings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_specialties",
                table: "specialties");

            migrationBuilder.DropIndex(
                name: "IX_medicationWarningJoins_MedicationId",
                table: "medicationWarningJoins");

            migrationBuilder.DropIndex(
                name: "IX_medicationWarningJoins_WarningId",
                table: "medicationWarningJoins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_medications",
                table: "medications");

            migrationBuilder.DropIndex(
                name: "IX_doctors_doctorspecialtyId",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "warnings");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "specialties");

            migrationBuilder.DropColumn(
                name: "MedicationId",
                table: "medicationWarningJoins");

            migrationBuilder.DropColumn(
                name: "WarningId",
                table: "medicationWarningJoins");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "medications");

            migrationBuilder.DropColumn(
                name: "doctorspecialtyId",
                table: "doctors");

            migrationBuilder.AlterColumn<string>(
                name: "WarningName",
                table: "warnings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "specialties",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "MedicationName",
                table: "medicationWarningJoins",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WarningName",
                table: "medicationWarningJoins",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "medications",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "doctorspecialty",
                table: "doctors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_warnings",
                table: "warnings",
                column: "WarningName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_specialties",
                table: "specialties",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_medications",
                table: "medications",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_medicationWarningJoins_MedicationName",
                table: "medicationWarningJoins",
                column: "MedicationName");

            migrationBuilder.CreateIndex(
                name: "IX_medicationWarningJoins_WarningName",
                table: "medicationWarningJoins",
                column: "WarningName");

            migrationBuilder.CreateIndex(
                name: "IX_doctors_doctorspecialty",
                table: "doctors",
                column: "doctorspecialty");

            migrationBuilder.AddForeignKey(
                name: "FK_doctors_specialties_doctorspecialty",
                table: "doctors",
                column: "doctorspecialty",
                principalTable: "specialties",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_medicationWarningJoins_medications_MedicationName",
                table: "medicationWarningJoins",
                column: "MedicationName",
                principalTable: "medications",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_medicationWarningJoins_warnings_WarningName",
                table: "medicationWarningJoins",
                column: "WarningName",
                principalTable: "warnings",
                principalColumn: "WarningName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
