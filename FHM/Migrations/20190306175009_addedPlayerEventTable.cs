using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FHM.Migrations
{
    public partial class addedPlayerEventTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player_Event",
                columns: table => new
                {
                    RegID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventTournamentID = table.Column<int>(nullable: true),
                    Paid = table.Column<bool>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    RegTime = table.Column<DateTime>(nullable: false),
                    StoreCredit = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player_Event", x => x.RegID);
                    table.ForeignKey(
                        name: "FK_Player_Event_Tournaments_EventTournamentID",
                        column: x => x.EventTournamentID,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Player_Event_AspNetUsers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Player_Event_EventTournamentID",
                table: "Player_Event",
                column: "EventTournamentID");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Event_PlayerId",
                table: "Player_Event",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Player_Event");
        }
    }
}
