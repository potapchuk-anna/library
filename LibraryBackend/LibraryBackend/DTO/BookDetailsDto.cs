using FluentValidation;
using LibraryBackend.Models;

namespace LibraryBackend.DTO
{
    public class BookDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Cover { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public double Rating { get; set; }
        public List<ReviewDto>? Reviews { get; set; }

        public class BookDetailsDtoValidator : AbstractValidator<BookDetailsDto>
        {
            public BookDetailsDtoValidator()
            {
                RuleFor(b => b.Id).NotEmpty();
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
}
