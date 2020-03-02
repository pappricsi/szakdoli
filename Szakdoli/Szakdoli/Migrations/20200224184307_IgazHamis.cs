using Microsoft.EntityFrameworkCore.Migrations;

namespace Szakdoli.Migrations
{
    public partial class IgazHamis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lokaciok_Raklapok_RaklapId",
                table: "Lokaciok");

            migrationBuilder.DropIndex(
                name: "IX_Lokaciok_RaklapId",
                table: "Lokaciok");

            migrationBuilder.DropColumn(
                name: "RaklapId",
                table: "Lokaciok");

            migrationBuilder.AddColumn<int>(
                name: "LokacioId",
                table: "Raklapok",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Foglalt",
                table: "Lokaciok",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Raklapok_LokacioId",
                table: "Raklapok",
                column: "LokacioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Raklapok_Lokaciok_LokacioId",
                table: "Raklapok",
                column: "LokacioId",
                principalTable: "Lokaciok",
                principalColumn: "LokacioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Raklapok_Lokaciok_LokacioId",
                table: "Raklapok");

            migrationBuilder.DropIndex(
                name: "IX_Raklapok_LokacioId",
                table: "Raklapok");

            migrationBuilder.DropColumn(
                name: "LokacioId",
                table: "Raklapok");

            migrationBuilder.DropColumn(
                name: "Foglalt",
                table: "Lokaciok");

            migrationBuilder.AddColumn<int>(
                name: "RaklapId",
                table: "Lokaciok",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lokaciok_RaklapId",
                table: "Lokaciok",
                column: "RaklapId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lokaciok_Raklapok_RaklapId",
                table: "Lokaciok",
                column: "RaklapId",
                principalTable: "Raklapok",
                principalColumn: "RaklapSzam",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
