using BookStoreNTier.Core.Entities;

namespace BookStoreNTier.Core.Repositories;

public interface IBookRepository 
{
    Task<Book> GetByIdAsync(int id);
    Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author);
    Task AddAsync(Book book);

}