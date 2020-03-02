using Microsoft.EntityFrameworkCore.Migrations;

namespace Szakdoli.Migrations
{
    public partial class Keszlet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Keszlet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TermekTipusId = table.Column<string>(nullable: true),
                    RaktarId = table.Column<int>(nullable: false),
                    Mennyiseg = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keszlet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Keszlet_Raktarak_RaktarId",
                        column: x => x.RaktarId,
                        principalTable: "Raktarak",
                        principalColumn: "RaktarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Keszlet_TermekTipusok_TermekTipusId",
                        column: x => x.TermekTipusId,
                        principalTable: "TermekTipusok",
                        principalColumn: "TipusNev",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Keszlet_RaktarId",
                table: "Keszlet",
                column: "RaktarId");

            migrationBuilder.CreateIndex(
                name: "IX_Keszlet_TermekTipusId",
                table: "Keszlet",
                column: "TermekTipusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Keszlet");
        }
    }
}
