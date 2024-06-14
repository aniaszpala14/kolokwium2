using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace kolos2.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "characters",
                columns: table => new
                {
                    IdCharacter = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CurrentWeight = table.Column<int>(type: "int", nullable: false),
                    MaxWeight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_characters", x => x.IdCharacter);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    IdItem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.IdItem);
                });

            migrationBuilder.CreateTable(
                name: "titles",
                columns: table => new
                {
                    IdTitle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_titles", x => x.IdTitle);
                });

            migrationBuilder.CreateTable(
                name: "backpacks",
                columns: table => new
                {
                    IdCharacter = table.Column<int>(type: "int", nullable: false),
                    IdItem = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_backpacks", x => new { x.IdCharacter, x.IdItem });
                    table.ForeignKey(
                        name: "FK_backpacks_characters_IdCharacter",
                        column: x => x.IdCharacter,
                        principalTable: "characters",
                        principalColumn: "IdCharacter",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_backpacks_items_IdItem",
                        column: x => x.IdItem,
                        principalTable: "items",
                        principalColumn: "IdItem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "character_titles",
                columns: table => new
                {
                    IdCharacter = table.Column<int>(type: "int", nullable: false),
                    IdTitle = table.Column<int>(type: "int", nullable: false),
                    AcquiredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_character_titles", x => new { x.IdCharacter, x.IdTitle });
                    table.ForeignKey(
                        name: "FK_character_titles_characters_IdCharacter",
                        column: x => x.IdCharacter,
                        principalTable: "characters",
                        principalColumn: "IdCharacter",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_character_titles_titles_IdTitle",
                        column: x => x.IdTitle,
                        principalTable: "titles",
                        principalColumn: "IdTitle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "characters",
                columns: new[] { "IdCharacter", "CurrentWeight", "FirstName", "LastName", "MaxWeight" },
                values: new object[,]
                {
                    { 1, 12, "Jan", "Kowalski", 30 },
                    { 2, 10, "Janina", "Kowalska", 20 },
                    { 3, 15, "Janusz", "Drabina", 25 },
                    { 4, 1, "Joasia", "Nowak", 10 },
                    { 5, 0, "Kasia", "Farba", 45 },
                    { 6, 12, "Krzysztof", "Krawczyk", 31000 }
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "IdItem", "Name", "Weight" },
                values: new object[,]
                {
                    { 1, "Glove", 5 },
                    { 2, "Sword", 10 },
                    { 3, "Goblin", 15 },
                    { 4, "Hat", 1 },
                    { 5, "Mushroom", 5 },
                    { 6, "Pepper", 12 },
                    { 7, "Potion", 3 },
                    { 8, "Cat", 13 }
                });

            migrationBuilder.InsertData(
                table: "titles",
                columns: new[] { "IdTitle", "Name" },
                values: new object[,]
                {
                    { 1, "Archer" },
                    { 2, "Wizard" },
                    { 3, "Ruler" },
                    { 4, "Magician" },
                    { 5, "Princess" },
                    { 6, "Fighter" }
                });

            migrationBuilder.InsertData(
                table: "backpacks",
                columns: new[] { "IdCharacter", "IdItem", "Amount" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 2, 1 },
                    { 3, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "character_titles",
                columns: new[] { "IdCharacter", "IdTitle", "AcquiredAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 14, 14, 30, 1, 827, DateTimeKind.Local).AddTicks(1442) },
                    { 2, 2, new DateTime(2024, 6, 14, 14, 30, 1, 829, DateTimeKind.Local).AddTicks(7098) },
                    { 3, 3, new DateTime(2024, 6, 14, 14, 30, 1, 829, DateTimeKind.Local).AddTicks(7128) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_backpacks_IdItem",
                table: "backpacks",
                column: "IdItem");

            migrationBuilder.CreateIndex(
                name: "IX_character_titles_IdTitle",
                table: "character_titles",
                column: "IdTitle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "backpacks");

            migrationBuilder.DropTable(
                name: "character_titles");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "characters");

            migrationBuilder.DropTable(
                name: "titles");
        }
    }
}
