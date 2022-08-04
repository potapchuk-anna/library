using FluentValidation;
using LibraryBackend.Models;

namespace LibraryBackend.DTO
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Reviewer { get; set; } = string.Empty;
    }
    public class ReviewDtoValidation : AbstractValidator<ReviewDto>
    {
        public ReviewDtoValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Message).NotEmpty();
            RuleFor(x => x.Reviewer).NotEmpty();
        }
    }
}
