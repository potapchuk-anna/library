using FluentValidation;

namespace LibraryBackend.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
       
    }
    public class RatingValidation : AbstractValidator<Rating>
    {
        public RatingValidation()
        {
            RuleFor(b => b.Id).NotEmpty();
            RuleFor(b => b.Score)
                 .GreaterThanOrEqualTo(1)
                 .LessThanOrEqualTo(5);
            RuleFor(b => b.BookId)
                .GreaterThanOrEqualTo(1);
        }
    }
}
