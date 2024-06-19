namespace BookstoreManagement.Application.UseCases.Books.Delete;

public class DeleteBookByIdUseCase
{
    public void Execute(string id, PersistBookUseCase persistBookUseCase)
    {
        persistBookUseCase.DeleteBook(id);
    }
}
