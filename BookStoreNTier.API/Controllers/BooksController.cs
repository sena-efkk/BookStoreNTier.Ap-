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
            var result =await _bookService.GetAllBooksAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //savaden soraki yönlendirme
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _bookService.GetBookByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        
        [HttpPost]
        public async Task<IActionResult> Save(CreateBookDto createBookDto)
        {
            // Service katmanına DTO'yu gönderiyoruz.
            var result =await _bookService.AddBookAsync(createBookDto);
            if (result.Success)
            {
                return CreatedAtAction(nameof(GetAll),new {id = result.Data.Id},result);
            }
            return BadRequest(result);
        }

    }
}