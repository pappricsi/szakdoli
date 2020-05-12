using Microsoft.EntityFrameworkCore.Migrations;

namespace Szakdoli.Migrations
{
    public partial class AdminRaktar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Raktarak_RaktarID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "InputModel");

            migrationBuilder.AlterColumn<int>(
                name: "RaktarID",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Raktarak_RaktarID",
                table: "AspNetUsers",
                column: "RaktarID",
                principalTable: "Raktarak",
                principalColumn: "RaktarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Raktarak_RaktarID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "RaktarID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "InputModel",
                columns: table => new
                {
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Raktar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeljesNev = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Raktarak_RaktarID",
                table: "AspNetUsers",
                column: "RaktarID",
                principalTable: "Raktarak",
                principalColumn: "RaktarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
