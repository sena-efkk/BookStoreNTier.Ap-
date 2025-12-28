using BookStoreNTier.Core.Utilities.Results;
using BookStoreNTier.Service.DTOs;

namespace BookStoreNTier.Service.Services.Interface
{
    public interface IBookService
    {
        Task<IDataResult<IEnumerable<BookDto>>> GetAllBooksAsync();
        // Task<BookDto> GetBookByIdAsync(int id); artık IDataResult döndürecek 
        Task<IDataResult<BookDto>> GetBookByIdAsync(int id);
        // Task<BookDto> AddBookAsync(CreateBookDto createBookDto);
        Task<IDataResult<BookDto>> AddBookAsync(CreateBookDto createBookDto);
    }
}