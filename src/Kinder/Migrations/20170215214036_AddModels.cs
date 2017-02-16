using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kinder.Migrations
{
    public partial class AddModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plunders",
                columns: table => new
                {
                    PlunderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlunderAttack = table.Column<int>(nullable: false),
                    PlunderDefense = table.Column<int>(nullable: false),
                    PlunderHP = table.Column<int>(nullable: false),
                    PlunderName = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plunders", x => x.PlunderId);
                });

            migrationBuilder.CreateTable(
                name: "FoeLocations",
                columns: table => new
                {
                    FoeLocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FoeAttack = table.Column<int>(nullable: false),
                    FoeHP = table.Column<int>(nullable: false),
                    FoeName = table.Column<string>(nullable: true),
                    LocationName = table.Column<string>(nullable: true),
                    PlunderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoeLocations", x => x.FoeLocationId);
                    table.ForeignKey(
                        name: "FK_FoeLocations_Plunders_PlunderId",
                        column: x => x.PlunderId,
                        principalTable: "Plunders",
                        principalColumn: "PlunderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Armour = table.Column<int>(nullable: false),
                    PlayerAttack = table.Column<int>(nullable: false),
                    PlayerDefense = table.Column<int>(nullable: false),
                    PlayerHP = table.Column<int>(nullable: false),
                    PlayerName = table.Column<string>(nullable: true),
                    PlunderId = table.Column<int>(nullable: true),
                    Potion = table.Column<int>(nullable: false),
                    Shield = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Weapon = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_Plunders_PlunderId",
                        column: x => x.PlunderId,
                        principalTable: "Plunders",
                        principalColumn: "PlunderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoeLocations_PlunderId",
                table: "FoeLocations",
                column: "PlunderId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlunderId",
                table: "Players",
                column: "PlunderId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                table: "Players",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoeLocations");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Plunders");
        }
    }
}
