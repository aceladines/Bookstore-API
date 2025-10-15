namespace Bookstore.Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; private set; }
        public Guid BookId { get; private set; }
        public int Quantity { get; private set; }
        public decimal BookPrice { get; private set; }
        public decimal SubTotal => BookPrice * Quantity;

        private OrderItem() { } // For EF

        public OrderItem(Guid bookId, int quantity, decimal price)
        {
            Id = Guid.NewGuid();
            BookId = bookId;
            Quantity = quantity;
            BookPrice = price;
        }

        public void IncreaseQuantity(int quantity)
        {
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than 0");

            Quantity += quantity;
        }

        public void DecreaseQuantity(int quantity)
        {
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than 0");

            if (quantity > Quantity) throw new ArgumentOutOfRangeException(nameof(quantity), $"Cannot remove more than the remaining quantity of {Quantity}");

            Quantity -= quantity;
        }
    }
}
