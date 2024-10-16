using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinica.API.Migrations
{
    /// <inheritdoc />
    public partial class All : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consults_Diagnoses_DiagnosesId",
                table: "Consults");

            migrationBuilder.DropColumn(
                name: "Diagnosis",
                table: "Consults");

            migrationBuilder.RenameColumn(
                name: "DiagnosesId",
                table: "Consults",
                newName: "DiagnosisId");

            migrationBuilder.RenameIndex(
                name: "IX_Consults_DiagnosesId",
                table: "Consults",
                newName: "IX_Consults_DiagnosisId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ConsultDate",
                table: "Consults",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ConsultDate",
                table: "Agendas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Consults_Diagnoses_DiagnosisId",
                table: "Consults",
                column: "DiagnosisId",
                principalTable: "Diagnoses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consults_Diagnoses_DiagnosisId",
                table: "Consults");

            migrationBuilder.RenameColumn(
                name: "DiagnosisId",
                table: "Consults",
                newName: "DiagnosesId");

            migrationBuilder.RenameIndex(
                name: "IX_Consults_DiagnosisId",
                table: "Consults",
                newName: "IX_Consults_DiagnosesId");

            migrationBuilder.AlterColumn<string>(
                name: "ConsultDate",
                table: "Consults",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Diagnosis",
                table: "Consults",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ConsultDate",
                table: "Agendas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Consults_Diagnoses_DiagnosesId",
                table: "Consults",
                column: "DiagnosesId",
                principalTable: "Diagnoses",
                principalColumn: "Id");
        }
    }
}
