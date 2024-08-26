using Microsoft.EntityFrameworkCore;
using ProductsCatalogService.API.Model.Entities;

namespace ProductsCatalogService.API.Model.Data
{
    public class ProductsDbContext:DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options):base(options) 
        {
            //config db
        }

        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                 new Product
                 {
                     ProductId = 1,
                     ProductName = "Wireless Headphones",
                     ProductDescription = "Noise-cancelling over-ear headphones with Bluetooth connectivity.",
                     ProductCategory = "Electronics",
                     Brand = "SoundPro",
                     Price = 150,
                     IsAvailable = true,
                     Country = "USA"
                 },
                new Product
                {
                    ProductId = 2,
                    ProductName = "Smartphone",
                    ProductDescription = "Latest model with 128GB storage, 5G, and a high-resolution camera.",
                    ProductCategory = "Electronics",
                    Brand = "TechCorp",
                    Price = 799,
                    IsAvailable = true,
                    Country = "China"
                },
                new Product
                {
                    ProductId = 3,
                    ProductName = "Running Shoes",
                    ProductDescription = "Lightweight running shoes with breathable mesh upper.",
                    ProductCategory = "Footwear",
                    Brand = "RunFast",
                    Price = 120,
                    IsAvailable = true,
                    Country = "Germany"
                },
                new Product
                {
                    ProductId = 4,
                    ProductName = "Electric Kettle",
                    ProductDescription = "1.5-liter electric kettle with auto shut-off and boil-dry protection.",
                    ProductCategory = "Home Appliances",
                    Brand = "KitchenMaster",
                    Price = 40,
                    IsAvailable = true,
                    Country = "UK"
                },
                new Product
                {
                    ProductId = 5,
                    ProductName = "Wrist Watch",
                    ProductDescription = "Stainless steel analog wristwatch with water resistance.",
                    ProductCategory = "Accessories",
                    Brand = "TimePiece",
                    Price = 250,
                    IsAvailable = true,
                    Country = "Switzerland"
                },
                new Product
                {
                    ProductId = 6,
                    ProductName = "Gaming Laptop",
                    ProductDescription = "High-performance laptop with 16GB RAM, 512GB SSD, and GTX 1660 Ti.",
                    ProductCategory = "Electronics",
                    Brand = "GameOn",
                    Price = 1200,
                    IsAvailable = false,
                    Country = "USA"
                },
                new Product
                {
                    ProductId = 7,
                    ProductName = "Blender",
                    ProductDescription = "500-watt blender with multiple speed settings and a pulse feature.",
                    ProductCategory = "Home Appliances",
                    Brand = "SmoothieMaster",
                    Price = 70,
                    IsAvailable = true,
                    Country = "Canada"
                },
                new Product
                {
                    ProductId = 8,
                    ProductName = "Leather Jacket",
                    ProductDescription = "Genuine leather biker jacket with zipper closure and side pockets.",
                    ProductCategory = "Clothing",
                    Brand = "FashionWear",
                    Price = 300,
                    IsAvailable = true,
                    Country = "Italy"
                },
                new Product
                {
                    ProductId = 9,
                    ProductName = "Tablet",
                    ProductDescription = "10-inch tablet with 64GB storage and HD display.",
                    ProductCategory = "Electronics",
                    Brand = "TabTech",
                    Price = 250,
                    IsAvailable = true,
                    Country = "South Korea"
                },
                new Product
                {
                    ProductId = 10,
                    ProductName = "Digital Camera",
                    ProductDescription = "24MP DSLR camera with a versatile lens kit.",
                    ProductCategory = "Electronics",
                    Brand = "PhotoSnap",
                    Price = 500,
                    IsAvailable = false,
                    Country = "Japan"
                }
                );
            
        }
    }
}
