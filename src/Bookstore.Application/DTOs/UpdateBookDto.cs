namespace Bookstore.Application.DTOs
{
    public record UpdateBookDto(string Title, string Author, decimal Price, int StockQuantity);
}
