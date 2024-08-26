using BookCatalogService.API.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogService.API.Model.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // First, seed the Authors and Categories
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Author 1", Biography = "Biography 1" },
                new Author { Id = 2, Name = "Author 2", Biography = "Biography 2" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fiction" },
                new Category { Id = 2, Name = "Science" }
            );

            // Then, seed the Books
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Book 1",
                    ISBN = "1111",
                    AuthorId = 1,
                    CategoryId = 1,
                    PublishedDate = new DateTime(2020, 1, 1)
                },
                new Book
                {
                    Id = 2,
                    Title = "Book 2",
                    ISBN = "2222",
                    AuthorId = 2,
                    CategoryId = 2,
                    PublishedDate = new DateTime(2021, 1, 1)
                }
            );
        }


        }
}
