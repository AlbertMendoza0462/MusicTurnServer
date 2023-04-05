using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicTurn.Migrations
{
    /// <inheritdoc />
    public partial class AddColaCanciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColaCanciones",
                columns: table => new
                {
                    ColaCancionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CancionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaPeticion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColaCanciones", x => x.ColaCancionId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColaCanciones");
        }
    }
}
