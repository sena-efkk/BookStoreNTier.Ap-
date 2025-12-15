using BookStoreNTier.Service.DTOs;
using BookStoreNTier.Service.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreNTier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BooksController :ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService books)
        {
            this._bookService=books;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books =await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> Save(CreateBookDto createBookDto)
        {
            // Service katmanına DTO'yu gönderiyoruz.
            var newBook =await _bookService.AddBookAsync(createBookDto);
            return CreatedAtAction(nameof(GetAll),new {id = newBook.Id},newBook);

        }

    }
}