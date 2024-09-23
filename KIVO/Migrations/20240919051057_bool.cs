using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KIVO.Migrations
{
    /// <inheritdoc />
    public partial class @bool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicos_EspecialidadMedicas_EspecialidadMedicaId",
                table: "Medicos");

            migrationBuilder.DropIndex(
                name: "IX_Medicos_EspecialidadMedicaId",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "EspecialidadMedicaId",
                table: "Medicos");

            migrationBuilder.AddColumn<int>(
                name: "EspecialidadMedicoId",
                table: "Medicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HaConfiguradoOrganizacion",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_EspecialidadMedicoId",
                table: "Medicos",
                column: "EspecialidadMedicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicos_EspecialidadMedicas_EspecialidadMedicoId",
                table: "Medicos",
                column: "EspecialidadMedicoId",
                principalTable: "EspecialidadMedicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicos_EspecialidadMedicas_EspecialidadMedicoId",
                table: "Medicos");

            migrationBuilder.DropIndex(
                name: "IX_Medicos_EspecialidadMedicoId",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "EspecialidadMedicoId",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "HaConfiguradoOrganizacion",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "EspecialidadMedicaId",
                table: "Medicos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_EspecialidadMedicaId",
                table: "Medicos",
                column: "EspecialidadMedicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicos_EspecialidadMedicas_EspecialidadMedicaId",
                table: "Medicos",
                column: "EspecialidadMedicaId",
                principalTable: "EspecialidadMedicas",
                principalColumn: "Id");
        }
    }
}
