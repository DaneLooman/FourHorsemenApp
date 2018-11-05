using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FHM.Data.Migrations
{
    public partial class addGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameImageThumbnailURL = table.Column<string>(nullable: true),
                    GameImageUrl = table.Column<string>(nullable: true),
                    GameIsGameOfTheWeek = table.Column<bool>(nullable: false),
                    GameLongDescription = table.Column<string>(maxLength: 5000, nullable: false),
                    GameName = table.Column<string>(maxLength: 100, nullable: false),
                    GameShortDescription = table.Column<string>(maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
