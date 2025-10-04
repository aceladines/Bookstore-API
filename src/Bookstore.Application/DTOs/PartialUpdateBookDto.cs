namespace Bookstore.Application.DTOs
{
    public class PartialUpdateBookDto
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public decimal? Price { get; set; }
        public int? StockQuantity { get; set; }
    }
}
