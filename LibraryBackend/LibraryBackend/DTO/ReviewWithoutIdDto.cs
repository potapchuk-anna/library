using FluentValidation;

namespace LibraryBackend.DTO
{
    public class ReviewWithoutIdDto
    {
        public string Message { get; set; } = string.Empty;
        public string Reviewer { get; set; } = string.Empty;
        public class ReviewWithoutIdDtoValidation : AbstractValidator<ReviewWithoutIdDto>
        {
            public ReviewWithoutIdDtoValidation()
            {
                RuleFor(x => x.Message).NotEmpty();
                RuleFor(x => x.Reviewer).NotEmpty();
            }
        }
    }
}
