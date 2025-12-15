using BookStoreNTier.Core.Entities;
using BookStoreNTier.Core.Repositories;
using BookStoreNTier.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookStoreNTier.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            // Context.Set<T>() diyerek generic bir tablo seçimi yapıyoruz.
            // T Category ise _dbSet Categories tablosu olur.
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync(); // GEÇİCİ OLARAK BURAYA EKLEDİK??
        }

        public Task Addasync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Book bookEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}