using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DemoProject.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AchterNaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumAangemaakt = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laptop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Merk = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Processor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RamInGB = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GPU = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptop", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prijs = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bestelling",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestelling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bestelling_Klant_KlantId",
                        column: x => x.KlantId,
                        principalTable: "Klant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLijn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BestellingId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Aantal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLijn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLijn_Bestelling_BestellingId",
                        column: x => x.BestellingId,
                        principalTable: "Bestelling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLijn_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Klant",
                columns: new[] { "Id", "AchterNaam", "DatumAangemaakt", "Voornaam" },
                values: new object[,]
                {
                    { 1, "Janssens", new DateOnly(2023, 1, 15), "Jan" },
                    { 2, "Peeters", new DateOnly(2023, 2, 20), "Sophie" },
                    { 3, "Maes", new DateOnly(2023, 4, 10), "Lucas" },
                    { 4, "Jacobs", new DateOnly(2023, 5, 2), "Emma" },
                    { 5, "Willems", new DateOnly(2023, 6, 18), "Liam" },
                    { 6, "Mertens", new DateOnly(2023, 7, 22), "Olivia" },
                    { 7, "Claes", new DateOnly(2023, 8, 30), "Noah" },
                    { 8, "Goossens", new DateOnly(2023, 9, 14), "Ella" },
                    { 9, "Wouters", new DateOnly(2023, 11, 5), "Arthur" },
                    { 10, "De Smet", new DateOnly(2024, 1, 12), "Mila" }
                });

            migrationBuilder.InsertData(
                table: "Laptop",
                columns: new[] { "Id", "GPU", "Merk", "Price", "Processor", "RamInGB" },
                values: new object[,]
                {
                    { 1, "RTX 3050", "Acer", 699m, "Intel I7", 16 },
                    { 2, "RTX 4060", "ASUS", 1299m, "Intel i7", 16 },
                    { 3, "RTX 3060", "Lenovo", 899m, "AMD Ryzen 7", 16 },
                    { 4, "Integrated", "HP", 549m, "Intel i5", 8 },
                    { 5, "RTX 4070", "MSI", 1899m, "Intel i9", 32 },
                    { 6, "M3 10-core", "Apple", 1499m, "Apple M3", 16 },
                    { 7, "RTX 3050 Ti", "Dell", 1099m, "Intel i7", 16 },
                    { 8, "RTX 4080", "Gigabyte", 2199m, "AMD Ryzen 9", 32 },
                    { 9, "Integrated", "Acer", 429m, "AMD Ryzen 3", 8 },
                    { 10, "RTX 4090", "Razer", 2799m, "Intel i9", 32 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Beschrijving", "Naam", "Prijs" },
                values: new object[,]
                {
                    { 1, "Allround workstation", "Laptop", 999.00m },
                    { 2, "Krachtige desktop-computer", "Pc", 1299.49m },
                    { 3, "Spuitbus voor stofreiniging", "Perslucht", 14.99m },
                    { 4, "RGB gaming toetsenbord", "Mechanisch Toetsenbord", 89.95m },
                    { 5, "Ergonomische optische muis", "Draadloze Muis", 34.50m },
                    { 6, "4K Ultra HD IPS scherm", "27 inch Monitor", 329.00m },
                    { 7, "Noise-cancelling gaming headset", "Headset", 79.99m },
                    { 8, "7-in-1 adapter met HDMI", "USB-C Hub", 45.00m },
                    { 9, "Full HD webcam met microfoon", "Webcam 1080p", 59.90m },
                    { 10, "Snelle USB 3.2 draagbare schijf", "Externe SSD 1TB", 112.50m }
                });

            migrationBuilder.InsertData(
                table: "Bestelling",
                columns: new[] { "Id", "KlantId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 4 },
                    { 6, 5 },
                    { 7, 6 },
                    { 8, 7 },
                    { 9, 8 },
                    { 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "OrderLijn",
                columns: new[] { "Id", "Aantal", "BestellingId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 1, 5 },
                    { 3, 5, 2, 3 },
                    { 4, 1, 3, 2 },
                    { 5, 2, 3, 6 },
                    { 6, 1, 4, 4 },
                    { 7, 1, 5, 10 },
                    { 8, 1, 6, 7 },
                    { 9, 3, 7, 8 },
                    { 10, 1, 8, 9 },
                    { 11, 10, 9, 3 },
                    { 12, 1, 10, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bestelling_KlantId",
                table: "Bestelling",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLijn_BestellingId",
                table: "OrderLijn",
                column: "BestellingId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLijn_ProductId",
                table: "OrderLijn",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Laptop");

            migrationBuilder.DropTable(
                name: "OrderLijn");

            migrationBuilder.DropTable(
                name: "Bestelling");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Klant");
        }
    }
}
