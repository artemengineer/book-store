using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreAPI.Data;
using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repositories
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DataBaseContext _context;

        public DatingRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<List<Book>> GetSelectedBooks(int id)
        {
            return await _context.SelectedBooks.Where(n => n.UserId == id).Select(i => i.Book).ToListAsync();
        }

        public async Task<Book> GetBook(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
        }

//        public async Task<SelectedBook> Selected(SelectedBook selectedBook)
//        {
//            await _context.SelectedBooks.AddAsync(selectedBook);
//            await _context.SaveChangesAsync();
//
//            return selectedBook;
//        }

        public async Task<SelectedBook> GetSelectedBook(int userId, int bookId)
        {
            return await _context.SelectedBooks.FirstOrDefaultAsync(b => b.UserId == userId && b.BookId == bookId);
        }

        public void Selected(SelectedBook selectedBook)
        {
            _context.SelectedBooks.Add(selectedBook);
            _context.SaveChanges();
        }

        public void Delete(SelectedBook selectedBook)
        {
            _context.SelectedBooks.Remove(selectedBook);
            _context.SaveChanges();
        }
    }
}