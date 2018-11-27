using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FHM.Migrations
{
    public partial class addedTournaments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TournamentID",
                table: "PlayerIDs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    TournamentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameID = table.Column<int>(nullable: false),
                    IsMajorTournament = table.Column<bool>(nullable: false),
                    TournamentDescription = table.Column<string>(maxLength: 5000, nullable: false),
                    TournamentFee = table.Column<decimal>(nullable: false),
                    TournamentFormatFormatID = table.Column<int>(nullable: true),
                    TournamentName = table.Column<string>(maxLength: 100, nullable: false),
                    TournamentStartTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.TournamentID);
                    table.ForeignKey(
                        name: "FK_Tournaments_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tournaments_Formats_TournamentFormatFormatID",
                        column: x => x.TournamentFormatFormatID,
                        principalTable: "Formats",
                        principalColumn: "FormatID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerIDs_TournamentID",
                table: "PlayerIDs",
                column: "TournamentID");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_GameID",
                table: "Tournaments",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_TournamentFormatFormatID",
                table: "Tournaments",
                column: "TournamentFormatFormatID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerIDs_Tournaments_TournamentID",
                table: "PlayerIDs",
                column: "TournamentID",
                principalTable: "Tournaments",
                principalColumn: "TournamentID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerIDs_Tournaments_TournamentID",
                table: "PlayerIDs");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_PlayerIDs_TournamentID",
                table: "PlayerIDs");

            migrationBuilder.DropColumn(
                name: "TournamentID",
                table: "PlayerIDs");
        }
    }
}
