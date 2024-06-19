using BookstoreManagement.Communication.Requests;
using BookstoreManagement.Communication.Responses;

namespace BookstoreManagement.Application.UseCases.Books.Update;

public class UpdateBookUseCase
{
    public void Execute(string id, RequestUpdateBookJson request, PersistBookUseCase persistBookUseCase)
    {

       persistBookUseCase.UpdateBook(id, request);

    }
}
