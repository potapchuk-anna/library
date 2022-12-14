using Microsoft.EntityFrameworkCore;

namespace LibraryBackend.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Book>(b =>
            {
                b.HasData(
                new Book { Id = 1, Title = "Harry Potter 1", Author = "Joanna Rowling", Content = "Smth", Cover = "path1", Genre = "fantasy" },
                new Book { Id = 2, Title = "Harry Potter 3", Author = "AJoanna Rowling", Content = "Smth", Cover = "path1", Genre = "fantasy" },
                new Book { Id = 3, Title = "Harry Potter 4", Author = "BJoanna Rowling", Content = "Smth", Cover = "path1", Genre = "horror" },
                new Book { Id = 4, Title = "Harry Potter 5", Author = "BJoanna Rowling", Content = "Smth", Cover = "path1", Genre = "horror" },
                new Book { Id = 5, Title = "Harry Potter 6", Author = "BJoanna Rowling", Content = "Smth", Cover = "path1", Genre = "horror" },
                new Book { Id = 6, Title = "Harry Potter 7", Author = "BJoanna Rowling", Content = "Smth", Cover = "path1", Genre = "horror" },
                new Book { Id = 7, Title = "Else", Author = "BJoanna Rowling", Content = "Smth", Cover = "path1", Genre = "horror" },
                new Book { Id = 8, Title = "Anna", Author = "BJoanna Rowling", Content = "Smth", Cover = "path1", Genre = "horror" },
                new Book { Id = 9, Title = "Cat", Author = "BJoanna Rowling", Content = "Smth", Cover = "path1", Genre = "horror" },
                new Book { Id = 10, Title = "Dog", Author = "BJoanna Rowling", Content = "Smth", Cover = "path1", Genre = "horror" });
            });
            modelBuilder.Entity<Rating>().HasData(
                new Rating { Id = 1, BookId = 1, Score = 5 },
                new Rating { Id = 2, BookId = 2, Score = 4 },
                new Rating { Id = 3, BookId = 2, Score = 1 },
                new Rating { Id = 4, BookId = 1, Score = 3 },
                new Rating { Id = 5, BookId = 3, Score = 5 },
                new Rating { Id = 6, BookId = 1, Score = 5 },
                new Rating { Id = 7, BookId = 3, Score = 4 }
                );
            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 1, BookId = 1, Message = "Good", Reviewer = "Anton" },
                new Review { Id = 2, BookId = 2, Message = "Bad", Reviewer = "Anton" },
                new Review { Id = 3, BookId = 2, Message = "Good", Reviewer = "Anton" },
                new Review { Id = 4, BookId = 2, Message = "Bad", Reviewer = "Anton" },
                new Review { Id = 5, BookId = 1, Message = "Bad", Reviewer = "Anton" },
                new Review { Id = 6, BookId = 3, Message = "Good", Reviewer = "Anton" },
                new Review { Id = 7, BookId = 3, Message = "Bad", Reviewer = "Anton" },
                new Review { Id = 8, BookId = 1, Message = "Good", Reviewer = "Anton" },
                new Review { Id = 9, BookId = 1, Message = "Good", Reviewer = "Anton" },
                new Review { Id = 10, BookId = 1, Message = "Good", Reviewer = "Anton" },
                new Review { Id = 11, BookId = 1, Message = "Good", Reviewer = "Anton" },
                new Review { Id = 12, BookId = 1, Message = "Good", Reviewer = "Anton" },
                new Review { Id = 13, BookId = 1, Message = "Good", Reviewer = "Anton" },
                new Review { Id = 14, BookId = 1, Message = "Good", Reviewer = "Anton" },
                new Review { Id = 15, BookId = 1, Message = "Good", Reviewer = "Anton" },
                new Review { Id = 16, BookId = 1, Message = "Good", Reviewer = "Anton" }
                );
        }
    }
}

