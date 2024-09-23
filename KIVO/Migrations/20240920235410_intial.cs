using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KIVO.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DuracionEnMeses",
                table: "PlanSuscripcions",
                newName: "DuracionEnDias");

            migrationBuilder.AddColumn<bool>(
                name: "IsFree",
                table: "PlanSuscripcions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFree",
                table: "PlanSuscripcions");

            migrationBuilder.RenameColumn(
                name: "DuracionEnDias",
                table: "PlanSuscripcions",
                newName: "DuracionEnMeses");
        }
    }
}
