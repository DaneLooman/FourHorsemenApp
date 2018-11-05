using Microsoft.EntityFrameworkCore.Migrations;

namespace FHM.Data.Migrations
{
    public partial class addedFormat2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Format_Game_GameID",
                table: "Format");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Format",
                table: "Format");

            migrationBuilder.RenameTable(
                name: "Format",
                newName: "Formats");

            migrationBuilder.RenameIndex(
                name: "IX_Format_GameID",
                table: "Formats",
                newName: "IX_Formats_GameID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Formats",
                table: "Formats",
                column: "FormatID");

            migrationBuilder.AddForeignKey(
                name: "FK_Formats_Game_GameID",
                table: "Formats",
                column: "GameID",
                principalTable: "Game",
                principalColumn: "GameID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formats_Game_GameID",
                table: "Formats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Formats",
                table: "Formats");

            migrationBuilder.RenameTable(
                name: "Formats",
                newName: "Format");

            migrationBuilder.RenameIndex(
                name: "IX_Formats_GameID",
                table: "Format",
                newName: "IX_Format_GameID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Format",
                table: "Format",
                column: "FormatID");

            migrationBuilder.AddForeignKey(
                name: "FK_Format_Game_GameID",
                table: "Format",
                column: "GameID",
                principalTable: "Game",
                principalColumn: "GameID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
