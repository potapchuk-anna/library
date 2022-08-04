using LibraryBackend.DTO;

namespace LibraryBackend.Services
{
    public interface IReviewRepository
    {
        public Task<int> AddReviewAsync(ReviewWithoutIdDto newReview, int bookId);
    }
}
