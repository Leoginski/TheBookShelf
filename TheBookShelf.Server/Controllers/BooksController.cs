using Microsoft.AspNetCore.Mvc;
using TheBookShelf.Application.DTOs.Requests;
using TheBookShelf.Application.DTOs.Responses;
using TheBookShelf.Domain.Interfaces.Services;

namespace TheBookShelf.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BooksController : ControllerBase
    {
        private IBookService _service;

        public BooksController(IBookService BookService) => _service = BookService;


        [HttpGet("Search")]
        [ProducesResponseType(typeof(IEnumerable<BookResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BookResponse>>> SearchAsync(string? author, string? isbn, bool? loved, int pageSize = 10, int pageOffset = 1)
        {
            var Books = await _service.SearchAsync(author, isbn, loved, pageSize, pageOffset);

            var BooksResponse = Books.Select(BookResponse.ToResponse);

            return Ok(BooksResponse);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BookResponse>>> GetAllAsync()
        {
            var Books = await _service.GetAllAsync();

            var BooksResponse = Books.Select(BookResponse.ToResponse);

            return Ok(BooksResponse);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<BookResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<BookResponse>> GetById(int id)
        {
            var Book = await _service.GetByIdAsync(id);
            if (Book is null)
                return NotFound();

            var bookResponse = BookResponse.ToResponse(Book);

            return Ok(bookResponse);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> InsertAsync(InsertBookRequest BookRequest)
        {
            var Book = InsertBookRequest.ToEntity(BookRequest);

            var id = (int)await _service.AddAsync(Book);

            return CreatedAtAction(nameof(GetById), new { id = id }, id);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateAsync(UpdateBookRequest request)
        {
            var entity = UpdateBookRequest.ToEntity(request);

            await _service.UpdateAsync(entity);

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteByIdAsync(int id)
        {
            await _service.DeleteByIdAsync(id);

            return Ok();
        }
    }
}
