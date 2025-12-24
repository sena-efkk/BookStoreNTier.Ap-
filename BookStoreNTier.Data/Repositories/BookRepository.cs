using BookStoreNTier.Core.Entities;
using BookStoreNTier.Core.Repositories;
using BookStoreNTier.Data.Context;

namespace BookStoreNTier.Data.Repositories;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _dbContext ;

    public BookRepository(AppDbContext dbContext)
    {
        this._dbContext= dbContext;
        
    }
    public async Task<Book> GetByIdAsync(int id)
    {
        return await _dbContext.Books.FindAsync(id);
    }

    public Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Book book)
    {
        throw new NotImplementedException();
    }
}