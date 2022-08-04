using FluentValidation;

namespace LibraryBackend.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public int BookId { get; set; }
        public string Reviewer { get; set; } = string.Empty;
        public Book Book { get; set; }
        
    }
    public class ReviewValidation : AbstractValidator<Review>
    {
        public ReviewValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Message).NotEmpty();
            RuleFor(x => x.Reviewer).NotEmpty();
            RuleFor(b => b.BookId)
                .NotEmpty()
                .GreaterThanOrEqualTo(1)
                .WithMessage("Book Id cannot be less than 1.");
        }
    }
}
