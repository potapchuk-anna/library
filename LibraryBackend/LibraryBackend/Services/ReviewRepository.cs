using LibraryBackend.DTO;
using LibraryBackend.Models;

namespace LibraryBackend.Services
{
    public class ReviewRepository: IReviewRepository
    {
        private readonly LibraryContext _context;

        public ReviewRepository(LibraryContext context)
        {
            _context = context;
        }
        public async Task<int> AddReviewAsync(ReviewWithoutIdDto newReview, int bookId)
        {
            Review review = new Review();
            review.Message = newReview.Message;
            review.Reviewer = newReview.Reviewer;
            review.BookId = bookId;
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review.Id;
        }
    }
}
