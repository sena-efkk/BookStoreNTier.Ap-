using BookStoreNTier.Service.DTOs;

namespace BookStoreNTier.Service.Services.Interface
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<BookDto> GetBookByIdAsync(int id);
        Task<BookDto> AddBookAsync(CreateBookDto createBookDto);
    }
}