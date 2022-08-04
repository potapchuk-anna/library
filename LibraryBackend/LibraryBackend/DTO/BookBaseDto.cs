using FluentValidation;

namespace LibraryBackend.DTO
{
    public class BookBaseDto
    {
        public int? Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Cover { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
    }
    public class BookBaseDtoValidator : AbstractValidator<BookBaseDto>
    {
        public BookBaseDtoValidator()
        {
            When(b => b.Id is not null && b.Id != 0, () =>
            {
                RuleFor(b => b.Id).GreaterThanOrEqualTo(1);
            });
            RuleFor(b => b.Title).NotEmpty();
            RuleFor(b => b.Author)
                .Must(value => !value.Any(char.IsDigit))
                .WithMessage("Name or surname cannot contain digit.");
            RuleFor(b => b.Genre)
                .Must(value => !value.Any(char.IsDigit))
                .WithMessage("Name or surname cannot contain digit.");
        }
    }
}
