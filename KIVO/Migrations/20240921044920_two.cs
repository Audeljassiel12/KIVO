using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KIVO.Migrations
{
    /// <inheritdoc />
    public partial class two : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PlanSuscripcions",
                columns: new[] { "Id", "Descripcion", "DuracionEnDias", "IsFree", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "Este es un plan gratuito con acceso limitado.", 30, true, "Plan Básico", 0m },
                    { 2, "Acceso a todas las funcionalidades por 1 mes.", 30, false, "Plan Estándar", 29.99m },
                    { 3, "Acceso ilimitado por 3 meses.", 90, false, "Plan Premium", 99.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlanSuscripcions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlanSuscripcions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlanSuscripcions",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
