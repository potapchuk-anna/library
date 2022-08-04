using LibraryBackend.DTO;
using LibraryBackend.Models;

namespace LibraryBackend.Services
{
    public class RatingRepository : IRatingRepository
    {
        private readonly LibraryContext _context;

        public RatingRepository(LibraryContext context)
        {
            _context = context;
        }
        public async Task SaveRatingAsync(int bookId, RatingDto newRating)
        {
            Rating rating = new Rating();
            rating.BookId = bookId;
            rating.Score = newRating.Score;
            _context.Ratings.Add(rating);
            await _context.SaveChangesAsync();
        }
    }
}
