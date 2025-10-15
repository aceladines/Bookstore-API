namespace Bookstore.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public User? User { get; private set; }
        private readonly List<OrderItem> _items = [];
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
        public decimal TotalAmount => Items.Sum(order => order.SubTotal);
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private Order() { } // For EF

        public Order(Guid userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddItem(Guid BookId, decimal price, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));

            var existingItem = _items.FirstOrDefault(i => i.BookId == BookId);

            if (existingItem is not null)
            {
                existingItem.IncreaseQuantity(quantity);
            }
            else
            {
                _items.Add(new OrderItem(BookId, quantity, price));
            }

            UpdatedAt = DateTime.UtcNow;
        }

        public void RemoveItem(Guid BookId)
        {
            var item = _items.FirstOrDefault(i => i.BookId == BookId);
            if (item is null) return;

            _items.Remove(item);

            UpdatedAt = DateTime.UtcNow;
        }
    }
}
