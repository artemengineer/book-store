using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreAPI.EntityFramework;
using BookStoreAPI.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repositories
{
    
    public class BookRepository : IBookRepository
    {
        private readonly DataBaseContext _context;

        public BookRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

       
        public async Task<List<Book>> GetSelectedBooks(int userId)
        {
            return await _context.SelectedBooks.Where(sb => sb.UserId == userId).Select(sb => sb.Book).ToListAsync();
        }

        
        public async Task<Book> GetBook(int bookId)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.Id == bookId);
        }

        
        public async Task<bool> IsSelectedBook(int userId, int bookId)
        {
            return await _context.SelectedBooks.AnyAsync(sb => sb.UserId == userId && sb.BookId == bookId);
        }

        
        public void AddSelectedBook(SelectedBook selectedBook)
        {
            _context.SelectedBooks.Add(selectedBook);
            _context.SaveChanges();
        }

        public void Delete(SelectedBook selectedBook)
        {
            _context.SelectedBooks.Attach(selectedBook);
            _context.SelectedBooks.Remove(selectedBook);
            _context.SaveChanges();
        }
    }
}