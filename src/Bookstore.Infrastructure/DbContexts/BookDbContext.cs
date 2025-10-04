using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class BookDbContext : DbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    {
    }

    // Define DbSets for each entity
    public DbSet<Book> Books { get; set; }

}
