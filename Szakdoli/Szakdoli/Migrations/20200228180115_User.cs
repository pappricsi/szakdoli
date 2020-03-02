using Microsoft.EntityFrameworkCore.Migrations;

namespace Szakdoli.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Raktarak_RaktarId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Raktarak_RaktarId",
                table: "AspNetUsers",
                column: "RaktarId",
                principalTable: "Raktarak",
                principalColumn: "RaktarId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Raktarak_RaktarId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Raktarak_RaktarId",
                table: "AspNetUsers",
                column: "RaktarId",
                principalTable: "Raktarak",
                principalColumn: "RaktarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
