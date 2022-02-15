using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Escola.Data.Migrations
{
    public partial class Migration_Criacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Cpf = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunoCurso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AlunoId = table.Column<Guid>(type: "uuid", nullable: false),
                    CursoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoCurso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunoCurso_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoCurso_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoNota",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AlunoCursoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Bimeste = table.Column<int>(type: "integer", nullable: false),
                    Nota = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoNota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunoNota_AlunoCurso_AlunoCursoId",
                        column: x => x.AlunoCursoId,
                        principalTable: "AlunoCurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoCurso_AlunoId",
                table: "AlunoCurso",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoCurso_CursoId",
                table: "AlunoCurso",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoNota_AlunoCursoId",
                table: "AlunoNota",
                column: "AlunoCursoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoNota");

            migrationBuilder.DropTable(
                name: "AlunoCurso");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Curso");
        }
    }
}
