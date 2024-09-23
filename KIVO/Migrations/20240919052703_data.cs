using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KIVO.Migrations
{
    /// <inheritdoc />
    public partial class data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EspecialidadMedicas",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Cardiología" },
                    { 2, "Pediatría" },
                    { 3, "Dermatología" },
                    { 4, "Oftalmología" },
                    { 5, "Neurología" },
                    { 6, "Ginecología" },
                    { 7, "Psiquiatría" },
                    { 8, "Ortopedia" },
                    { 9, "Neumología" },
                    { 10, "Endocrinología" },
                    { 11, "Gastroenterología" },
                    { 12, "Oncología" },
                    { 13, "Urología" },
                    { 14, "Nefrología" },
                    { 15, "Hematología" },
                    { 16, "Infectología" },
                    { 17, "Reumatología" },
                    { 18, "Otorrinolaringología" },
                    { 19, "Cirugía General" },
                    { 20, "Cirugía Plástica" },
                    { 21, "Medicina Interna" },
                    { 22, "Medicina Familiar" },
                    { 23, "Medicina del Deporte" },
                    { 24, "Geriatría" },
                    { 25, "Traumatología" },
                    { 26, "Neurocirugía" },
                    { 27, "Anestesiología" },
                    { 28, "Radiología" },
                    { 29, "Patología" },
                    { 30, "Neonatología" },
                    { 31, "Allergología" },
                    { 32, "Medicina Nuclear" },
                    { 33, "Toxicología" },
                    { 34, "Fisiatría" },
                    { 35, "Cuidados Paliativos" },
                    { 36, "Enfermería" },
                    { 37, "Radiología" },
                    { 38, "Técnico de Laboratorio" },
                    { 39, "Farmacia" },
                    { 40, "Fisioterapia" },
                    { 41, "Nutrición" },
                    { 42, "Psicología" },
                    { 43, "Trabajador Social" },
                    { 44, "Administración de Salud" },
                    { 45, "Odontología" },
                    { 46, "Terapia Ocupacional" },
                    { 47, "Logopedia" },
                    { 48, "Alumnos/Internos" },
                    { 49, "Urgencias Médicas" },
                    { 50, "Paramédicos" },
                    { 51, "Gestión Administrativa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "EspecialidadMedicas",
                keyColumn: "Id",
                keyValue: 51);
        }
    }
}
