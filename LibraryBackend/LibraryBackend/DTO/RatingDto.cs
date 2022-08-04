using FluentValidation;
using LibraryBackend.Models;

namespace LibraryBackend.DTO
{
    public class RatingDto
    {
        public int Score { get; set; }
    }
    public class RatingDtoValidation : AbstractValidator<RatingDto>
    {
        public RatingDtoValidation()
        {
            RuleFor(b => b.Score)
                 .GreaterThanOrEqualTo(1)
                 .LessThanOrEqualTo(5);
        }
    }
}
