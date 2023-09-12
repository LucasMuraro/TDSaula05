using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aula005.RazorPages.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    CursoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeCurso = table.Column<string>(type: "TEXT", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    DateInicio = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateTermino = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.CursoId);
                });

            migrationBuilder.CreateTable(
                name: "Jogadores",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AlunoNome = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    DataInscricao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Cursos = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogadores", x => x.AlunoId);
                });

            migrationBuilder.CreateTable(
                name: "CursosEAlunos",
                columns: table => new
                {
                    CursoId = table.Column<int>(type: "INTEGER", nullable: false),
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursosEAlunos", x => new { x.CursoId, x.AlunoId });
                    table.ForeignKey(
                        name: "FK_CursosEAlunos_Eventos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Eventos",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursosEAlunos_Jogadores_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Jogadores",
                        principalColumn: "AlunoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursosEAlunos_AlunoId",
                table: "CursosEAlunos",
                column: "AlunoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursosEAlunos");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Jogadores");
        }
    }
}
