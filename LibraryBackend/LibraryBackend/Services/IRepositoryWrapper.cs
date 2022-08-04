namespace LibraryBackend.Services
{
    public interface IRepositoryWrapper
    {
        public IBookRepository Book { get; }
        public IReviewRepository Review { get; }
        public IRatingRepository Rating { get; }
    }
}
