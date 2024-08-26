using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductsCatalogService.API.Migrations
{
    /// <inheritdoc />
    public partial class dataseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Brand", "Country", "IsAvailable", "Price", "ProductCategory", "ProductDescription", "ProductName" },
                values: new object[,]
                {
                    { 1, "SoundPro", "USA", true, 150, "Electronics", "Noise-cancelling over-ear headphones with Bluetooth connectivity.", "Wireless Headphones" },
                    { 2, "TechCorp", "China", true, 799, "Electronics", "Latest model with 128GB storage, 5G, and a high-resolution camera.", "Smartphone" },
                    { 3, "RunFast", "Germany", true, 120, "Footwear", "Lightweight running shoes with breathable mesh upper.", "Running Shoes" },
                    { 4, "KitchenMaster", "UK", true, 40, "Home Appliances", "1.5-liter electric kettle with auto shut-off and boil-dry protection.", "Electric Kettle" },
                    { 5, "TimePiece", "Switzerland", true, 250, "Accessories", "Stainless steel analog wristwatch with water resistance.", "Wrist Watch" },
                    { 6, "GameOn", "USA", false, 1200, "Electronics", "High-performance laptop with 16GB RAM, 512GB SSD, and GTX 1660 Ti.", "Gaming Laptop" },
                    { 7, "SmoothieMaster", "Canada", true, 70, "Home Appliances", "500-watt blender with multiple speed settings and a pulse feature.", "Blender" },
                    { 8, "FashionWear", "Italy", true, 300, "Clothing", "Genuine leather biker jacket with zipper closure and side pockets.", "Leather Jacket" },
                    { 9, "TabTech", "South Korea", true, 250, "Electronics", "10-inch tablet with 64GB storage and HD display.", "Tablet" },
                    { 10, "PhotoSnap", "Japan", false, 500, "Electronics", "24MP DSLR camera with a versatile lens kit.", "Digital Camera" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);
        }
    }
}
