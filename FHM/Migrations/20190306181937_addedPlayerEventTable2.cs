using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FHM.Migrations
{
    public partial class addedPlayerEventTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Event_Tournaments_EventTournamentID",
                table: "Player_Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Event_AspNetUsers_PlayerId",
                table: "Player_Event");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Player_Event",
                table: "Player_Event");

            migrationBuilder.RenameTable(
                name: "Player_Event",
                newName: "Registrations");

            migrationBuilder.RenameIndex(
                name: "IX_Player_Event_PlayerId",
                table: "Registrations",
                newName: "IX_Registrations_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Player_Event_EventTournamentID",
                table: "Registrations",
                newName: "IX_Registrations_EventTournamentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Registrations",
                table: "Registrations",
                column: "RegID");

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Tournaments_EventTournamentID",
                table: "Registrations",
                column: "EventTournamentID",
                principalTable: "Tournaments",
                principalColumn: "TournamentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_AspNetUsers_PlayerId",
                table: "Registrations",
                column: "PlayerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Tournaments_EventTournamentID",
                table: "Registrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_AspNetUsers_PlayerId",
                table: "Registrations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Registrations",
                table: "Registrations");

            migrationBuilder.RenameTable(
                name: "Registrations",
                newName: "Player_Event");

            migrationBuilder.RenameIndex(
                name: "IX_Registrations_PlayerId",
                table: "Player_Event",
                newName: "IX_Player_Event_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Registrations_EventTournamentID",
                table: "Player_Event",
                newName: "IX_Player_Event_EventTournamentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Player_Event",
                table: "Player_Event",
                column: "RegID");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Event_Tournaments_EventTournamentID",
                table: "Player_Event",
                column: "EventTournamentID",
                principalTable: "Tournaments",
                principalColumn: "TournamentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Event_AspNetUsers_PlayerId",
                table: "Player_Event",
                column: "PlayerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
