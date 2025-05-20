using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eksamen2025Gruppe5.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColorInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Red = table.Column<int>(type: "INTEGER", nullable: false),
                    Green = table.Column<int>(type: "INTEGER", nullable: false),
                    Blue = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PollenRegistreringer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Dato = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Område = table.Column<string>(type: "TEXT", nullable: false),
                    Nivå = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollenRegistreringer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PollenResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollenResponses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DateInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PollenResponseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DateInfos_PollenResponses_PollenResponseId",
                        column: x => x.PollenResponseId,
                        principalTable: "PollenResponses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndexInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    DateInfoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ColorInfoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndexInfos_ColorInfos_ColorInfoId",
                        column: x => x.ColorInfoId,
                        principalTable: "ColorInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndexInfos_DateInfos_DateInfoId",
                        column: x => x.DateInfoId,
                        principalTable: "DateInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DateInfos_PollenResponseId",
                table: "DateInfos",
                column: "PollenResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_IndexInfos_ColorInfoId",
                table: "IndexInfos",
                column: "ColorInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_IndexInfos_DateInfoId",
                table: "IndexInfos",
                column: "DateInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndexInfos");

            migrationBuilder.DropTable(
                name: "PollenRegistreringer");

            migrationBuilder.DropTable(
                name: "ColorInfos");

            migrationBuilder.DropTable(
                name: "DateInfos");

            migrationBuilder.DropTable(
                name: "PollenResponses");
        }
    }
}
