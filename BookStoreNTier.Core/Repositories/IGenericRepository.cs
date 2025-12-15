using System.Buffers.Text;
using System.Linq.Expressions;
using BookStoreNTier.Core.Entities;

namespace BookStoreNTier.Core.Repositories
{
    public interface IGenericRepository<T> where T :BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();//öğrenmelisin

        IQueryable<T> Where(Expression<Func<T ,bool>> expression);  //filtreleyerek veri çeker  

        Task AddAsync(T entity );
        void Remove(T Entity); //veritabanına gitmez o sebeple void yani entity durumunu değiştirir
        void Update(T Entity);//veritabanına gitmez o sebeple void yani entity durumunu değiştirir
        Task AddAsync(Book bookEntity);
    }
}