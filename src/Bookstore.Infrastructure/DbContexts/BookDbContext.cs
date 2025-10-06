using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.DbContexts
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
        }

        // Define DbSets for each entity
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
