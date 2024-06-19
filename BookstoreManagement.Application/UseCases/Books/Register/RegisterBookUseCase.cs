using BookstoreManagement.Communication.Enums;
using BookstoreManagement.Communication.Requests;
using BookstoreManagement.Communication.Responses;

namespace BookstoreManagement.Application.UseCases.Books.Register;

public class RegisterBookUseCase
{
    public ResponseRegisteredBookJson Execute(RequestRegisterBookJson request, PersistBookUseCase persistBookUseCase)
    {

        Validate(request);

        var newBook = new ResponseBookJson
        {
            Id = Guid.NewGuid().ToString(),
            Title = request.Title,
            Author = request.Author,
            Price = request.Price,
            Stock = request.Stock,
            BookType = request.BookType,
        };

        persistBookUseCase.AddBook(newBook);

        var response = new ResponseRegisteredBookJson
        {
            Title = newBook.Title,
            Author = newBook.Author,
            Price = newBook.Price,
            Stock = newBook.Stock,
            BookType = newBook.BookType,
        };

        return response;
    }

    private void Validate(RequestRegisterBookJson request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            throw new ArgumentException("Title is required", nameof(request.Title));
        }

        if (string.IsNullOrWhiteSpace(request.Author))
        {
            throw new ArgumentException("Author is required", nameof(request.Author));
        }

        if (request.Price < 0)
        {
            throw new ArgumentException("Price must be greater than 0", nameof(request.Price));
        }

        if (request.Stock < 0)
        {
            throw new ArgumentException("Stock must be greater than or equal to 0", nameof(request.Stock));
        }

        var isBookTypeInvalid = !Enum.IsDefined(typeof(BookType), request.BookType);
        if (isBookTypeInvalid)
        {
            throw new ArgumentException("Book type is invalid", nameof(request.BookType));
        }
    }
}
