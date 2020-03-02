using Microsoft.EntityFrameworkCore.Migrations;

namespace Szakdoli.Migrations
{
    public partial class Termek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Raklapok_Termekek_TermekId",
                table: "Raklapok");

            migrationBuilder.DropIndex(
                name: "IX_Raklapok_TermekId",
                table: "Raklapok");

            migrationBuilder.DropColumn(
                name: "TermekId",
                table: "Raklapok");

            migrationBuilder.AddColumn<int>(
                name: "RaklapID",
                table: "Termekek",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Termekek_RaklapID",
                table: "Termekek",
                column: "RaklapID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Termekek_Raklapok_RaklapID",
                table: "Termekek",
                column: "RaklapID",
                principalTable: "Raklapok",
                principalColumn: "RaklapSzam",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Termekek_Raklapok_RaklapID",
                table: "Termekek");

            migrationBuilder.DropIndex(
                name: "IX_Termekek_RaklapID",
                table: "Termekek");

            migrationBuilder.DropColumn(
                name: "RaklapID",
                table: "Termekek");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "TermekId",
                table: "Raklapok",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Raklapok_TermekId",
                table: "Raklapok",
                column: "TermekId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Raklapok_Termekek_TermekId",
                table: "Raklapok",
                column: "TermekId",
                principalTable: "Termekek",
                principalColumn: "TermekID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
