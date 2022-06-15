using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProfessorCurso.Migrations
{
    public partial class Migracao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Professores_IdProfessorId",
                table: "Cursos");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_IdProfessorId",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "IdProfessorId",
                table: "Cursos");

            migrationBuilder.AddColumn<string>(
                name: "IdProfessor",
                table: "Cursos",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdProfessor",
                table: "Cursos");

            migrationBuilder.AddColumn<Guid>(
                name: "IdProfessorId",
                table: "Cursos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_IdProfessorId",
                table: "Cursos",
                column: "IdProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Professores_IdProfessorId",
                table: "Cursos",
                column: "IdProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
