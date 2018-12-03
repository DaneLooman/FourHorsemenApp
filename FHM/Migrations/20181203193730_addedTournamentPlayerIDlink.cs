using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FHM.Migrations
{
    public partial class addedTournamentPlayerIDlink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerIDs_Tournaments_TournamentID",
                table: "PlayerIDs");

            migrationBuilder.DropIndex(
                name: "IX_PlayerIDs_TournamentID",
                table: "PlayerIDs");

            migrationBuilder.DropColumn(
                name: "TournamentID",
                table: "PlayerIDs");

            migrationBuilder.CreateTable(
                name: "PlayerID_Tournament",
                columns: table => new
                {
                    PlayerIDID = table.Column<int>(nullable: false),
                    TournamentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerID_Tournament", x => new { x.PlayerIDID, x.TournamentID });
                    table.ForeignKey(
                        name: "FK_PlayerID_Tournament_PlayerIDs_PlayerIDID",
                        column: x => x.PlayerIDID,
                        principalTable: "PlayerIDs",
                        principalColumn: "PlayerIDID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerID_Tournament_Tournaments_TournamentID",
                        column: x => x.TournamentID,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerID_Tournament_TournamentID",
                table: "PlayerID_Tournament",
                column: "TournamentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerID_Tournament");

            migrationBuilder.AddColumn<int>(
                name: "TournamentID",
                table: "PlayerIDs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerIDs_TournamentID",
                table: "PlayerIDs",
                column: "TournamentID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerIDs_Tournaments_TournamentID",
                table: "PlayerIDs",
                column: "TournamentID",
                principalTable: "Tournaments",
                principalColumn: "TournamentID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
