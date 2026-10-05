using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoProject.Migrations
{
    /// <inheritdoc />
    public partial class restrictRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bestelling_Klant_KlantId",
                table: "Bestelling");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLijn_Bestelling_BestellingId",
                table: "OrderLijn");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLijn_Product_ProductId",
                table: "OrderLijn");

            migrationBuilder.AddForeignKey(
                name: "FK_Bestelling_Klant_KlantId",
                table: "Bestelling",
                column: "KlantId",
                principalTable: "Klant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLijn_Bestelling_BestellingId",
                table: "OrderLijn",
                column: "BestellingId",
                principalTable: "Bestelling",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLijn_Product_ProductId",
                table: "OrderLijn",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bestelling_Klant_KlantId",
                table: "Bestelling");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLijn_Bestelling_BestellingId",
                table: "OrderLijn");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLijn_Product_ProductId",
                table: "OrderLijn");

            migrationBuilder.AddForeignKey(
                name: "FK_Bestelling_Klant_KlantId",
                table: "Bestelling",
                column: "KlantId",
                principalTable: "Klant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLijn_Bestelling_BestellingId",
                table: "OrderLijn",
                column: "BestellingId",
                principalTable: "Bestelling",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLijn_Product_ProductId",
                table: "OrderLijn",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
