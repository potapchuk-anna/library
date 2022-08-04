using LibraryBackend.DTO;

namespace LibraryBackend.Services
{
    public interface IRatingRepository
    {
        public Task SaveRatingAsync(int bookId, RatingDto newRating);
    }
}
