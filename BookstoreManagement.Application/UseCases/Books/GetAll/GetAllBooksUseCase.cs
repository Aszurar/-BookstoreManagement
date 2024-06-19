using BookstoreManagement.Communication.Responses;

namespace BookstoreManagement.Application.UseCases.Books.GetAll;

public class GetAllBooksUseCase
{
    public ResponseListBooksJson Execute(ResponseListBooksJson books)
    {
        var response = books;
        return response;
    }
}
