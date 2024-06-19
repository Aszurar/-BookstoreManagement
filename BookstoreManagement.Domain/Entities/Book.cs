using BookstoreManagement.Domain.Enums;

namespace BookstoreManagement.Domain.Entities;

public class Book
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;

    public BookType BookType { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
