using LibraryBackend.Models;

namespace LibraryBackend.DTO
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public double Rating { get; set; }
        public int ReviewNumber { get; set; }

    }
}
