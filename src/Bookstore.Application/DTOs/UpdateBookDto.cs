using System.ComponentModel.DataAnnotations;

namespace Bookstore.Application.DTOs
{
    public record UpdateBookDto(
        [Required(ErrorMessage = "Title in required")]
        [StringLength(120, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 120 characters")]
        string Title,

        [Required(ErrorMessage = "Author in required")]
        [StringLength(120, ErrorMessage = "Author name cannot surpass 120 characters")]
        [RegularExpression(@"\S+", ErrorMessage = "Author name cannot be empty or whitespace")]
        string Author,

        [Required(ErrorMessage = "Price in required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        decimal Price,

        [Required(ErrorMessage = "Stock quantity in required")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative")]
        int StockQuantity
   );
}
