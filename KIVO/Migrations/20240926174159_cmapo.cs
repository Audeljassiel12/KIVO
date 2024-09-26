﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KIVO.Migrations
{
    /// <inheritdoc />
    public partial class cmapo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoPerfilUrl",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoPerfilUrl",
                table: "Pacientes");
        }
    }
}
