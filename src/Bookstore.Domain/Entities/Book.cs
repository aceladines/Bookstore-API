namespace Bookstore.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; internal set; }
        public string Title { get; internal set; }
        public string Author { get; internal set; }
        public decimal Price { get; internal set; }
        public int StockQuantity { get; internal set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public Book() { }


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
            {
                throw new ArgumentNullException(nameof(title), "Title must not be empty.");
            }

            Title = title;
        }

        public void UpdatePrice(decimal price)
        {
            if (price < 0)
            {
                throw new ArgumentException("Price cannot be less than 0.", nameof(price));
            }

            Price = price;
        }
    }
}
