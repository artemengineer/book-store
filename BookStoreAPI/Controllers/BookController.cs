using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BookStoreAPI.Dtos;
using BookStoreAPI.EntityFramework.Models;
using BookStoreAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repo;
        private readonly IMapper _mapper;

        public BookController(IBookRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetBooks(int userId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var booksAll = await _repo.GetBooks();
            var booksSelected = await _repo.GetSelectedBooks(userId);
            var booksToReturn = from book in booksAll
                select new BookDto
                {
                    Id = book.Id,
                    Name = book.Name,
                    Author = book.Author,
                    Description = book.Description,
                    IsSelected = booksSelected.Contains(book)
                };

            return Ok(booksToReturn);
        }

        [HttpGet("selected/{userId}")]
        public async Task<IActionResult> GetSelectedBooks(int userId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var books = await _repo.GetSelectedBooks(userId);
            var booksToReturn = from book in books
                select new BookDto
                {
                    Id = book.Id,
                    Name = book.Name,
                    Author = book.Author,
                    Description = book.Description,
                    IsSelected = true
                };

            return Ok(booksToReturn);
        }

        [HttpGet("detailed/{userId}/{bookId}")]
        public async Task<IActionResult> GetDetailedBook(int userId, int bookId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var book = await _repo.GetBook(bookId);
            var bookToReturn = _mapper.Map<BookDto>(book);
            var isSelectedBook = await _repo.IsSelectedBook(userId, bookId);

            if (isSelectedBook)
            {
                bookToReturn.IsSelected = true;
            }

            return Ok(bookToReturn);
        }

        [HttpPost("toggle-book-selection")]
        public async Task<IActionResult> ToggleBookSelection(BookSelectedDto bookSelectedDto)
        {
            if (bookSelectedDto.UserId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var isSelectedBook = await _repo.IsSelectedBook(bookSelectedDto.UserId, bookSelectedDto.BookId);
            var selectedBook = _mapper.Map<SelectedBook>(bookSelectedDto);
            if (isSelectedBook)
            {
                _repo.Delete(selectedBook);
            }
            else
            {
                _repo.AddSelectedBook(selectedBook);
            }

            return Ok();
        }
    }
}