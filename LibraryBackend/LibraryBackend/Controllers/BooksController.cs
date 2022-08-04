using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryBackend.Models;
using LibraryBackend.DTO;
using LibraryBackend.Services;

namespace LibraryBackend.Controllers
{
    [Route("api")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IRepositoryWrapper repository;
        private readonly IConfiguration _configuration;
        public BooksController(IRepositoryWrapper repository, IConfiguration configuration)
        {
            this.repository = repository;
            _configuration = configuration;
        }

        //###1
        [HttpGet]
        [Route("books")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetSortedBooks([FromQuery] string? order)
        {
            var books = repository.Book.GetBooks();
            if (books is null)
            {
                return NoContent();
            }

            if (order == "title")
            {
                return Ok(await books.OrderBy(b => b.Title).ToListAsync());
            }
            if (order == "author")
            {
                return Ok(await books.OrderBy(b => b.Author).ToListAsync());
            }
            if (string.IsNullOrEmpty(order))
            {
                return Ok(await books.ToListAsync());
            }
            return BadRequest();
        }
        //### 2
        [HttpGet]
        [Route("recomended")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetTop10Books([FromQuery] string? genre)
        {
            const int reviewNumber = 10;
            const int limit = 10;
            var books = repository.Book.GetBooksByGenre(genre);
            return Ok(await books
                      .OrderBy(b => b.Rating)
                      .Where(b => b.ReviewNumber > reviewNumber)
                      .Take(limit).ToListAsync());

        }


        //### 3
        [HttpGet]
        [Route("books/{id}")]
        public async Task<ActionResult<BookDetailsDto>> GetBookWithDetails([FromRoute] int id)
        {
            var book = await repository.Book.GetDetailedBookAsync(id);
            if (book is null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        //### 4
        // DELETE: api/books/5
        [HttpDelete]
        [Route("books/{id}")]
        public async Task<IActionResult> DeleteBook(int id, [FromQuery] string secret)
        {
            if (secret == this._configuration["delete-password"])
            {
                if (BookExists(id))
                {
                    await repository.Book.DeleteAsync(id);
                    return Ok();
                }
                return NotFound();
            }
            return NotFound();
        }

        //### 5
        [HttpPost]
        [Route("books/save")]
        public async Task<ActionResult<int>> SaveBookAsync([FromBody] BookBaseDto book)
        {
            if (book.Id is null || book.Id==0)
            {
                return Ok(await Task.Run(() => PostBook(book)));
            }
            int? id = PutBook(book.Id, book);
            if (id == -1)
            {
                return NoContent();
            }
            return Ok(id);
        }

        private async Task<int?> PostBook(BookBaseDto book)
        {
            await repository.Book.AddBookAsync(book);
            return book.Id;
        }

        [HttpPut]
        private int? PutBook(int? id, BookBaseDto book)
        {
            if (BookExists(id))
            {
                repository.Book.UpdateBookAsync(book, id);
                return book.Id;
            }
            return -1;
        }
        private bool BookExists(int? id)
        {
            return repository.Book.BookExists(id);
        }

        //### 6
        [HttpPut]
        [Route("books/{id}/review")]
        public async Task<ActionResult<int>> SaveReviewAsync([FromRoute] int id, [FromBody]ReviewWithoutIdDto review)
        {
            if (!BookExists(id))
            {
                return NotFound();
            }
            return Ok(await repository.Review.AddReviewAsync(review, id));
        }

        //### 7
        [HttpPut]
        [Route("books/{id}/rate")]
        public async Task<IActionResult> SaveRatingAsync([FromRoute] int id, [FromBody] RatingDto rating)
        {
            if (!BookExists(id))
            {
                return NotFound();
            }
            await repository.Rating.SaveRatingAsync(id, rating);
            return Ok();
        }
    }
}
