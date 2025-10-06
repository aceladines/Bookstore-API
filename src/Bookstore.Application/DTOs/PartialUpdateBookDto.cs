using System.ComponentModel.DataAnnotations;

namespace Bookstore.Application.DTOs
{
    public class PartialUpdateBookDto
    {
        [StringLength(120, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 120 characters")]
        public string? Title { get; set; }

        [StringLength(120, ErrorMessage = "Author name cannot surpass 120 characters")]
        [RegularExpression(@"\S+", ErrorMessage = "Author name cannot be empty or whitespace")]
        public string? Author { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335", ErrorMessage = "Price must be greater than zero")]
        public decimal? Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative")]
        public int? StockQuantity { get; set; }
    }
}
