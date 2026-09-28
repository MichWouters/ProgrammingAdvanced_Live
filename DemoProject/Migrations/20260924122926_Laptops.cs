using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DemoProject.Migrations
{
    /// <inheritdoc />
    public partial class Laptops : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Laptop");
        }
    }
}
