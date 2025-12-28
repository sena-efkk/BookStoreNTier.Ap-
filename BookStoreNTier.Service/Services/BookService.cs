using BookStoreNTier.Core.Entities;
using BookStoreNTier.Core.Repositories;
using BookStoreNTier.Core.Utilities.Results;
using BookStoreNTier.Service.DTOs;
using BookStoreNTier.Service.Services.Interface;

namespace BookStoreNTier.Service.Services
{
    public class BookService : IBookService
    {
        private readonly IGenericRepository<Book> _bookRepository;

        public BookService(IGenericRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IDataResult<IEnumerable<BookDto>>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();

            // MANUEL MAPPING (Amelelik ama Güvenli)
            // Veritabanından gelen Entity listesini, DTO listesine çeviriyoruz.
            var bookDtos = new List<BookDto>();

            foreach (var book in books)
            {
                bookDtos.Add(new BookDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Price = book.Price,
                    CategoryId = book.CategoryId,
                    // Category nesnesi dolu gelmediği için şimdilik null bırakıyoruz.
                    // (Repository'de Include yapmadık henüz)
                });
            }

            // DEĞİŞİM BURADA:
            // Listeyi çıplak dönmek yerine, "Başarılı" etiketi ve mesajıyla paketliyoruz.
            return new SuccessDataResult<IEnumerable<BookDto>>(bookDtos, "Kitaplar başarıyla listelendi.");
        }

        public async Task<IDataResult<BookDto>> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
            {
                return new ErrorDataResult<BookDto>("Aradığınız kitap bulunamadı.");
            }

            var bookDto = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Price = book.Price,
                CategoryId = book.CategoryId
            };
            // BAŞARILI İSE:
            return new SuccessDataResult<BookDto>(bookDto, "Kitap getirildi.");
        }

        public async Task<IDataResult<BookDto>> AddBookAsync(CreateBookDto createBookDto)
        {
            var bookEntity = new Book
            {
                Title = createBookDto.Title,
                Price = createBookDto.Price,
                CategoryId = createBookDto.CategoryId,
            };

            await _bookRepository.AddAsync(bookEntity);

            // BURADA EKSİK VAR: SaveChanges() çağrılmadı! 
            // UnitOfWork yapmadığımız için SaveChanges'i Repository'ye eklememiz gerekebilir 
            // ya da şimdilik repository'de AddAsync içine _context.SaveChanges() ekle.
            // (Bu konuyu sonra düzelteceğiz, şimdilik böyle kabul et)

            // 3. Geriye Oluşan Datayı DTO çevirelim
            var newBookDto = new BookDto
            {
                Id = bookEntity.Id,
                Title = bookEntity.Title,
                Price = bookEntity.Price,
                CategoryId = bookEntity.CategoryId
            };

            // Ekleme işlemi sonucu:
            return new SuccessDataResult<BookDto>(newBookDto, "Kitap başarıyla eklendi.");
            
        }
    }
}