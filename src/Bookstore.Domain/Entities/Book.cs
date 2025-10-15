namespace Bookstore.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }

#pragma warning disable CS8618 
        private Book() { } // EF Core constructor
#pragma warning restore CS8618


        public Book(string title, string author, decimal price, int stockQuantity)
        {
            Title = title;
            Author = author;
            Price = price;
            StockQuantity = stockQuantity;
        }

        public void UpdateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title must not be empty or whitespace.", nameof(title));

            Title = title;
        }

        public void UpdatePrice(decimal price)
        {
            if (price < 0)
                throw new ArgumentException("Price cannot be less than 0.", nameof(price));
            Price = price;
        }

        public void AddStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity to add must be greater than zero.", nameof(quantity));

            StockQuantity += quantity;
        }

        public void RemoveStock(int quantity)
        {
            if (quantity < 0)
                throw new ArgumentException("Quantity to remove must be positive.", nameof(quantity));

            if (quantity > StockQuantity)
                throw new InvalidOperationException("Insufficient stock to remove.");

            StockQuantity -= quantity;
        }
    }
}
