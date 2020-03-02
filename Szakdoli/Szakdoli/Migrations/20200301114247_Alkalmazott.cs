using Microsoft.EntityFrameworkCore.Migrations;

namespace Szakdoli.Migrations
{
    public partial class Alkalmazott : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Raktarak_RaktarId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "RaktarId",
                table: "AspNetUsers",
                newName: "RaktarID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_RaktarId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_RaktarID");

            migrationBuilder.AlterColumn<int>(
                name: "RaktarID",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Raktarak_RaktarID",
                table: "AspNetUsers",
                column: "RaktarID",
                principalTable: "Raktarak",
                principalColumn: "RaktarId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Raktarak_RaktarID",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "RaktarID",
                table: "AspNetUsers",
                newName: "RaktarId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_RaktarID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_RaktarId");

            migrationBuilder.AlterColumn<int>(
                name: "RaktarId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Raktarak_RaktarId",
                table: "AspNetUsers",
                column: "RaktarId",
                principalTable: "Raktarak",
                principalColumn: "RaktarId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
