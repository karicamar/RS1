using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Migrations
{
    public partial class akgodine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UpisAkGodine",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    akademskaGodina_id = table.Column<int>(type: "int", nullable: false),
                    evidentirao_id = table.Column<int>(type: "int", nullable: false),
                    godinaStudija = table.Column<int>(type: "int", nullable: false),
                    cijena = table.Column<float>(type: "real", nullable: false),
                    upisGod = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ovjeraGod = table.Column<DateTime>(type: "datetime2", nullable: true),
                    obnova = table.Column<bool>(type: "bit", nullable: false),
                    napomena = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpisAkGodine", x => x.id);
                    table.ForeignKey(
                        name: "FK_UpisAkGodine_AkademskaGodina_akademskaGodina_id",
                        column: x => x.akademskaGodina_id,
                        principalTable: "AkademskaGodina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UpisAkGodine_KorisnickiNalog_evidentirao_id",
                        column: x => x.evidentirao_id,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UpisAkGodine_Student_student_id",
                        column: x => x.student_id,
                        principalTable: "Student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UpisAkGodine_akademskaGodina_id",
                table: "UpisAkGodine",
                column: "akademskaGodina_id");

            migrationBuilder.CreateIndex(
                name: "IX_UpisAkGodine_evidentirao_id",
                table: "UpisAkGodine",
                column: "evidentirao_id");

            migrationBuilder.CreateIndex(
                name: "IX_UpisAkGodine_student_id",
                table: "UpisAkGodine",
                column: "student_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UpisAkGodine");
        }
    }
}
