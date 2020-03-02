using Microsoft.EntityFrameworkCore.Migrations;

namespace Szakdoli.Migrations
{
    public partial class RaktarJav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vezeto",
                table: "Raktarak");

            migrationBuilder.DropColumn(
                name: "AlkalmazottID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Tarhely",
                table: "Raktarak",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TeljesNev",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tarhely",
                table: "Raktarak");

            migrationBuilder.DropColumn(
                name: "TeljesNev",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Vezeto",
                table: "Raktarak",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AlkalmazottID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
