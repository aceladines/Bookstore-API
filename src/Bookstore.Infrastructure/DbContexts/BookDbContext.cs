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
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>(builder =>
            {
                builder.HasKey(o => o.Id);

                builder.HasMany(typeof(OrderItem), "_items")
                       .WithOne()
                       .HasForeignKey("OrderId")
                       .OnDelete(DeleteBehavior.Cascade);

                builder.Navigation("_items")
                       .UsePropertyAccessMode(PropertyAccessMode.Field);
            });

            modelBuilder.Entity<OrderItem>(builder =>
            {
                builder.HasKey(i => i.Id);
                builder.Property(i => i.BookPrice).HasPrecision(18, 2);
                builder.Property(i => i.Quantity).IsRequired();
            });
        }
    }
}
