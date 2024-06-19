
using BookstoreManagement.Application.UseCases.Books;
using BookstoreManagement.Application.UseCases.Books.Delete;
using BookstoreManagement.Application.UseCases.Books.GetAll;
using BookstoreManagement.Application.UseCases.Books.Register;
using BookstoreManagement.Application.UseCases.Books.Update;
using BookstoreManagement.Communication.Requests;
using BookstoreManagement.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreManagement.API.Controllers;
public class BooksController : BookstoreManagementBaseController
{

    [HttpGet]
    [ProducesResponseType(typeof(ResponseListBooksJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public IActionResult GetAll([FromServices] PersistBookUseCase persistBookUseCase)
    {
        try {
            var useCase = new GetAllBooksUseCase();
            var books = persistBookUseCase.GetAllBooks();
            var response = useCase.Execute(books);
            if (response.Books.Any())
            {
                return Ok(response);
            }

            return NoContent();

        } catch (Exception ex) {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredBookJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public IActionResult Create([FromBody] RequestRegisterBookJson request, [FromServices] PersistBookUseCase persistBookUseCase)
    {
        try
        {   
            var useCase = new RegisterBookUseCase();
            var response = useCase.Execute(request, persistBookUseCase);
            return Created(string.Empty, response);
        } catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public IActionResult Update([FromRoute] string id, [FromBody] RequestUpdateBookJson request, [FromServices] PersistBookUseCase persistBookUseCase)
    {
        try { 
            var useCase = new UpdateBookUseCase();
            useCase.Execute(id, request, persistBookUseCase);
            return NoContent();
        } catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteById([FromRoute] string id, [FromServices] PersistBookUseCase persistBookUseCase)
    {
        try
        {
            var useCase = new DeleteBookByIdUseCase();
            useCase.Execute(id, persistBookUseCase);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
