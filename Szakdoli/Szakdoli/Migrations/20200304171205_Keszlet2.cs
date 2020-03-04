using Microsoft.EntityFrameworkCore.Migrations;

namespace Szakdoli.Migrations
{
    public partial class Keszlet2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keszlet_TermekTipusok_TermekTipusId",
                table: "Keszlet");

            migrationBuilder.DropForeignKey(
                name: "FK_Termekek_TermekTipusok_TermekTipusId",
                table: "Termekek");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TermekTipusok",
                table: "TermekTipusok");

            migrationBuilder.DropIndex(
                name: "IX_Keszlet_TermekTipusId",
                table: "Keszlet");

            migrationBuilder.DropColumn(
                name: "Mennyiseg",
                table: "TermekTipusok");

            migrationBuilder.DropColumn(
                name: "Suly",
                table: "Termekek");

            migrationBuilder.AlterColumn<string>(
                name: "TipusNev",
                table: "TermekTipusok",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "TipusID",
                table: "TermekTipusok",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Suly",
                table: "TermekTipusok",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TermekTipusId",
                table: "Termekek",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TermekTipusId",
                table: "Keszlet",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TermekTipusTipusID",
                table: "Keszlet",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TermekTipusok",
                table: "TermekTipusok",
                column: "TipusID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Termekek_TermekTipusok_TermekTipusId",
                table: "Termekek",
                column: "TermekTipusId",
                principalTable: "TermekTipusok",
                principalColumn: "TipusID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keszlet_TermekTipusok_TermekTipusTipusID",
                table: "Keszlet");

            migrationBuilder.DropForeignKey(
                name: "FK_Termekek_TermekTipusok_TermekTipusId",
                table: "Termekek");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TermekTipusok",
                table: "TermekTipusok");

            migrationBuilder.DropIndex(
                name: "IX_Keszlet_TermekTipusTipusID",
                table: "Keszlet");

            migrationBuilder.DropColumn(
                name: "TipusID",
                table: "TermekTipusok");

            migrationBuilder.DropColumn(
                name: "Suly",
                table: "TermekTipusok");

            migrationBuilder.DropColumn(
                name: "TermekTipusTipusID",
                table: "Keszlet");

            migrationBuilder.AlterColumn<string>(
                name: "TipusNev",
                table: "TermekTipusok",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Mennyiseg",
                table: "TermekTipusok",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "TermekTipusId",
                table: "Termekek",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Suly",
                table: "Termekek",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "TermekTipusId",
                table: "Keszlet",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TermekTipusok",
                table: "TermekTipusok",
                column: "TipusNev");

            migrationBuilder.CreateIndex(
                name: "IX_Keszlet_TermekTipusId",
                table: "Keszlet",
                column: "TermekTipusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Keszlet_TermekTipusok_TermekTipusId",
                table: "Keszlet",
                column: "TermekTipusId",
                principalTable: "TermekTipusok",
                principalColumn: "TipusNev",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Termekek_TermekTipusok_TermekTipusId",
                table: "Termekek",
                column: "TermekTipusId",
                principalTable: "TermekTipusok",
                principalColumn: "TipusNev",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
