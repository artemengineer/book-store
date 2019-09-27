using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BookStoreAPI.Dtos;
using BookStoreAPI.Models;
using BookStoreAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BookStoreAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public BookController(IDatingRepository repo, IConfiguration config, IMapper mapper)
        {
            _config = config;
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooks(int id)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var booksAll = await _repo.GetBooks();
            var booksSelected = await _repo.GetSelectedBooks(id);
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

        [HttpGet("select/{id}")]
        public async Task<IActionResult> GetSelectedBooks(int id)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var books = await _repo.GetSelectedBooks(id);
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

        [HttpGet("detail/{userId}/{bookId}")]
        public async Task<IActionResult> GetDetailBook(int userId, int bookId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var book = await _repo.GetBook(bookId);
            var bookToReturn = _mapper.Map<BookDto>(book);
            var selectedBook = await _repo.GetSelectedBook(userId, bookId);

            if (selectedBook != null)
            {
                bookToReturn.IsSelected = true;
            }

            return Ok(bookToReturn);
        }

        [HttpPost("select")]
        public async Task<IActionResult> SelectedBook(BookSelectedDto bookSelectedDto)
        {
            if (bookSelectedDto.UserId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var selectedBook = await _repo.GetSelectedBook(bookSelectedDto.UserId, bookSelectedDto.BookId);
            if (selectedBook == null)
            {
                _repo.Selected(_mapper.Map<SelectedBook>(bookSelectedDto));
            }
            else
            {
                _repo.Delete(selectedBook);
            }

            return Ok();
        }
    }
}