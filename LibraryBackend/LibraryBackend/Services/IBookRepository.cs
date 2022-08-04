using LibraryBackend.DTO;

namespace LibraryBackend.Services
{
    public interface IBookRepository
    {
        public Task DeleteAsync(int id);
        public IQueryable<BookDto> GetBooks();
        public IQueryable<BookDto> GetBooksByGenre(string? genre);
        public Task<BookDetailsDto?> GetDetailedBookAsync(int id);
        public bool BookExists(int? id);
        public Task UpdateBookAsync(BookBaseDto newBook, int? id);
        public Task AddBookAsync(BookBaseDto newBook);
    }
}
