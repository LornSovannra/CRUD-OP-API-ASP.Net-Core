using CRUD_OP.Services;
using CRUD_OP.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_OP.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookServices bookServices;
        public BookController(IBookServices bookServices)
        {
            this.bookServices = bookServices;
        }

        [HttpGet("RetrieveBooks")]
        public IActionResult RetrieveBooks()
        {
            var books = bookServices.RetrieveBooks();

            return Ok(books.Result);
        }

        [HttpGet("RetriveBook/{id}")]
        public IActionResult RetriveBook(int id)
        {
            var book = bookServices.RetriveBook(id);

            if(!book.Result.IsSuccess)
                return BadRequest(book.Result);

            return Ok(book.Result);
        }

        [HttpPost("CreateBook")]
        public IActionResult CreateBook([FromForm] BookVM model)
        {
            var create_book = bookServices.CreateBook(model);

            if(!create_book.Result.IsSuccess)
                return BadRequest(create_book.Result);

            return Ok(create_book.Result);
        }

        [HttpPut("UpdateBook/{id}")]
        public IActionResult UpdateBook(int id, [FromForm] BookVM model)
        {
            var update_book = bookServices.UpdateBook(id, model);

            if(!update_book.Result.IsSuccess)
                return BadRequest(update_book.Result);

            return Ok(update_book.Result);
        }

        [HttpDelete("DeleteBook/{id}")]
        public IActionResult DeleteBook(int id)
        {
            var delete_book = bookServices.DeleteBook(id);

            if(!delete_book.Result.IsSuccess)
                return BadRequest(delete_book.Result);

            return Ok(delete_book.Result);
        }
    }
}
