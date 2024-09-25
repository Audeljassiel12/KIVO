using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KIVO.Migrations
{
    /// <inheritdoc />
    public partial class departamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Departamento 1" },
                    { 2, "Departamento 2" },
                    { 3, "Departamento 3" }
                });

            migrationBuilder.InsertData(
                table: "Ciudades",
                columns: new[] { "Id", "DepartamentoId", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Ciudad 1" },
                    { 2, 2, "Ciudad 2" },
                    { 3, 3, "Ciudad 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
