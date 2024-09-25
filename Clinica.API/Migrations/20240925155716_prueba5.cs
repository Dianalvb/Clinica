using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinica.API.Migrations
{
    /// <inheritdoc />
    public partial class prueba5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agendas_Name_Date",
                table: "Agendas");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Agendas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_Description",
                table: "Treatments",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Name",
                table: "Patients",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medications_Name",
                table: "Medications",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_Name",
                table: "Diagnoses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_Name",
                table: "Agendas",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Treatments_Description",
                table: "Treatments");

            migrationBuilder.DropIndex(
                name: "IX_Patients_Name",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Medications_Name",
                table: "Medications");

            migrationBuilder.DropIndex(
                name: "IX_Diagnoses_Name",
                table: "Diagnoses");

            migrationBuilder.DropIndex(
                name: "IX_Agendas_Name",
                table: "Agendas");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Agendas",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_Name_Date",
                table: "Agendas",
                columns: new[] { "Name", "Date" },
                unique: true);
        }
    }
}
