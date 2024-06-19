using BookstoreManagement.Communication.Requests;
using BookstoreManagement.Communication.Responses;

namespace BookstoreManagement.Application.UseCases.Books;

public class PersistBookUseCase
{
    private readonly ResponseListBooksJson _books;

    public PersistBookUseCase()
    {
        _books = new ResponseListBooksJson();
    }

    public ResponseListBooksJson GetAllBooks()
    {
        return _books;
    }

    public void AddBook(ResponseBookJson book)
    {
        _books.Books.Add(book);
    }

    public void UpdateBook(string id, RequestUpdateBookJson book)
    {
        var bookToUpdate = _books.Books.Find(book => book.Id == id);

        if (bookToUpdate == null) {
            throw new Exception("Book not found");
        }

        bookToUpdate.Title = book.Title ?? bookToUpdate.Title;
        bookToUpdate.Author = book.Author ?? bookToUpdate.Author;
        bookToUpdate.Price = book.Price ?? bookToUpdate.Price;
        bookToUpdate.Stock = book.Stock ?? bookToUpdate.Stock;
        bookToUpdate.BookType = book.BookType ?? bookToUpdate.BookType;
        
    }

    public void DeleteBook(string id)
    {
        var bookToDelete = _books.Books.Find(book => book.Id == id);

        if (bookToDelete == null)
        {
            throw new Exception("Book not found");
        }

        _books.Books.Remove(bookToDelete);
    }
 
}
