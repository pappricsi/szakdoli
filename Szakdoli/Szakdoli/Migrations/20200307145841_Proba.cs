using Microsoft.EntityFrameworkCore.Migrations;

namespace Szakdoli.Migrations
{
    public partial class Proba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keszlet_TermekTipusok_TermekTipusTipusID",
                table: "Keszlet");

            migrationBuilder.DropIndex(
                name: "IX_Keszlet_TermekTipusTipusID",
                table: "Keszlet");

            migrationBuilder.DropColumn(
                name: "TermekTipusTipusID",
                table: "Keszlet");

            migrationBuilder.AlterColumn<int>(
                name: "TermekTipusId",
                table: "Keszlet",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "InputModel",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: true),
                    Raktar = table.Column<string>(nullable: true),
                    TeljesNev = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_Keszlet_TermekTipusId",
                table: "Keszlet",
                column: "TermekTipusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Keszlet_TermekTipusok_TermekTipusId",
                table: "Keszlet",
                column: "TermekTipusId",
                principalTable: "TermekTipusok",
                principalColumn: "TipusID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keszlet_TermekTipusok_TermekTipusId",
                table: "Keszlet");

            migrationBuilder.DropTable(
                name: "InputModel");

            migrationBuilder.DropIndex(
                name: "IX_Keszlet_TermekTipusId",
                table: "Keszlet");

            migrationBuilder.AlterColumn<string>(
                name: "TermekTipusId",
                table: "Keszlet",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "TermekTipusTipusID",
                table: "Keszlet",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Keszlet_TermekTipusTipusID",
                table: "Keszlet",
                column: "TermekTipusTipusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Keszlet_TermekTipusok_TermekTipusTipusID",
                table: "Keszlet",
                column: "TermekTipusTipusID",
                principalTable: "TermekTipusok",
                principalColumn: "TipusID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
