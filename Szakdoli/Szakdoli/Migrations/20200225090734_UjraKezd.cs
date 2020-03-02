using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Szakdoli.Migrations
{
    public partial class UjraKezd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Termekek_Raklapok_RaklapID",
                table: "Termekek");

            migrationBuilder.DropTable(
                name: "Raklapok");

            migrationBuilder.DropIndex(
                name: "IX_Termekek_RaklapID",
                table: "Termekek");

            migrationBuilder.DropColumn(
                name: "Megnevezes",
                table: "Termekek");

            migrationBuilder.DropColumn(
                name: "RaklapID",
                table: "Termekek");

            migrationBuilder.DropColumn(
                name: "Tarhely",
                table: "Raktarak");

            migrationBuilder.AddColumn<DateTime>(
                name: "Betarazva",
                table: "Termekek",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LokacioId",
                table: "Termekek",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TermekTipusId",
                table: "Termekek",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RaktarId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TermekTipusok",
                columns: table => new
                {
                    TipusNev = table.Column<string>(nullable: false),
                    Mennyiseg = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermekTipusok", x => x.TipusNev);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Termekek_LokacioId",
                table: "Termekek",
                column: "LokacioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Termekek_TermekTipusId",
                table: "Termekek",
                column: "TermekTipusId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RaktarId",
                table: "AspNetUsers",
                column: "RaktarId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Raktarak_RaktarId",
                table: "AspNetUsers",
                column: "RaktarId",
                principalTable: "Raktarak",
                principalColumn: "RaktarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Termekek_Lokaciok_LokacioId",
                table: "Termekek",
                column: "LokacioId",
                principalTable: "Lokaciok",
                principalColumn: "LokacioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Termekek_TermekTipusok_TermekTipusId",
                table: "Termekek",
                column: "TermekTipusId",
                principalTable: "TermekTipusok",
                principalColumn: "TipusNev",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Raktarak_RaktarId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Termekek_Lokaciok_LokacioId",
                table: "Termekek");

            migrationBuilder.DropForeignKey(
                name: "FK_Termekek_TermekTipusok_TermekTipusId",
                table: "Termekek");

            migrationBuilder.DropTable(
                name: "TermekTipusok");

            migrationBuilder.DropIndex(
                name: "IX_Termekek_LokacioId",
                table: "Termekek");

            migrationBuilder.DropIndex(
                name: "IX_Termekek_TermekTipusId",
                table: "Termekek");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RaktarId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Betarazva",
                table: "Termekek");

            migrationBuilder.DropColumn(
                name: "LokacioId",
                table: "Termekek");

            migrationBuilder.DropColumn(
                name: "TermekTipusId",
                table: "Termekek");

            migrationBuilder.DropColumn(
                name: "RaktarId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Megnevezes",
                table: "Termekek",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RaklapID",
                table: "Termekek",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tarhely",
                table: "Raktarak",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Raklapok",
                columns: table => new
                {
                    RaklapSzam = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LokacioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raklapok", x => x.RaklapSzam);
                    table.ForeignKey(
                        name: "FK_Raklapok_Lokaciok_LokacioId",
                        column: x => x.LokacioId,
                        principalTable: "Lokaciok",
                        principalColumn: "LokacioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Termekek_RaklapID",
                table: "Termekek",
                column: "RaklapID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Raklapok_LokacioId",
                table: "Raklapok",
                column: "LokacioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Termekek_Raklapok_RaklapID",
                table: "Termekek",
                column: "RaklapID",
                principalTable: "Raklapok",
                principalColumn: "RaklapSzam",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
