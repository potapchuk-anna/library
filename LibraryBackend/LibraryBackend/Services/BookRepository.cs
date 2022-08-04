using LibraryBackend.DTO;
using LibraryBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryBackend.Services
{
    public class BookRepository:IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _context.Books.FirstAsync(b=>b.Id==id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public IQueryable<BookDto> GetBooks()
        {
            return _context.Books
                      .Include(b => b.Ratings)
                      .Include(b => b.Reviews)
                      .Select(b =>
                  new BookDto()
                  {
                      Id = b.Id,
                      Title = b.Title,
                      Author = b.Author,
                      Rating = b.Ratings.Count == 0 ? 0 : b.Ratings.Average(r => r.Score),
                      ReviewNumber = b.Reviews.Count
                  }
                  );
        }

        public IQueryable<BookDto> GetBooksByGenre(string? genre)
        {
            return  _context.Books
                      .Include(b => b.Ratings)
                      .Include(b => b.Reviews)
                      .Where(b => b.Genre.Contains(
                          string.IsNullOrEmpty(genre) ? "" : genre)
                      ).Select(b =>
                  new BookDto()
                  {
                      Id = b.Id,
                      Title = b.Title,
                      Author = b.Author,
                      Rating = b.Ratings.Count == 0 ? 0 : b.Ratings.Average(r => r.Score),
                      ReviewNumber = b.Reviews.Count
                  });
        }

        public async Task<BookDetailsDto?> GetDetailedBookAsync(int id)
        {
            return await  _context.Books
                .Include(b => b.Ratings)
                .Include(b => b.Reviews)             
                .Select(b =>
                new BookDetailsDto()
                {
                    Title = b.Title,
                    Id = b.Id,
                    Author = b.Author,
                    Content = b.Content,
                    Cover = b.Cover,
                    Reviews = b.Reviews
                    .Select(r =>
                        new ReviewDto()
                        {
                            Id = r.Id,
                            Message = r.Message,
                            Reviewer = r.Reviewer,
                        }).ToList(),
                    Rating = b.Ratings.Count == 0 ? 0 : b.Ratings.Average(r => r.Score)
                })
                .FirstOrDefaultAsync(b=>b.Id==id);
        }
        public bool BookExists(int? id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
        public async Task UpdateBookAsync(BookBaseDto newBook, int? id)
        {
            Book book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            book.Title = newBook.Title;
            book.Author= newBook.Author;
            book.Content = newBook.Content;
            book.Cover = newBook.Cover;
            book.Genre = newBook.Genre;

            _context.Books.Update(book);    
            await _context.SaveChangesAsync();
        }
        public async Task AddBookAsync(BookBaseDto newBook)
        {
            Book book = new Book();
            book.Title = newBook.Title;
            book.Author = newBook.Author;
            book.Content = newBook.Content;
            book.Cover = newBook.Cover;
            book.Genre = newBook.Genre;
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            newBook.Id = book.Id;
        }       
    }
}
