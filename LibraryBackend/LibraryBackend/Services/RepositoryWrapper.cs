using LibraryBackend.Models;

namespace LibraryBackend.Services
{
    public class RepositoryWrapper:IRepositoryWrapper
    {
       
        public RepositoryWrapper(IBookRepository bookRepository, IReviewRepository reviewRepository, IRatingRepository ratingRepository)
        {
            this.Book = bookRepository;
            this.Review = reviewRepository;
            this.Rating = ratingRepository;
        }
        public IBookRepository Book { get; }
        public IReviewRepository Review { get; }
        public IRatingRepository Rating { get; }
    }
}
