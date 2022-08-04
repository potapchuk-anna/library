using FluentValidation;

namespace LibraryBackend.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Cover { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;

        public List<Review>? Reviews { get; set; }
        public List<Rating>? Ratings { get; set; }      

    }
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b => b.Id).NotEmpty();
            RuleFor(b => b.Title).NotEmpty();
            RuleFor(b => b.Author)
                .Must(value=>!value.Any(char.IsDigit))
                .WithMessage("Name or surname cannot contain digit.");
            RuleFor(b => b.Genre)
                .Must(value=>!value.Any(char.IsDigit))
                .WithMessage("Name or surname cannot contain digit.");
        }
    }
}
