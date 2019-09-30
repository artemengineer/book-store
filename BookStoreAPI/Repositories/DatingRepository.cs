using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreAPI.EntityFramework;
using BookStoreAPI.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repositories
{
    public class DatingRepository : IDatingRepository // TODO: Dating?
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

        // TODO: Answer: 
        // TODO: Да userId правильней, спешил решил упростить.
        // 
        public async Task<List<Book>> GetSelectedBooks(int id) // TODO: Может, лучше userId параметр?
        {
            return await _context.SelectedBooks.Where(n => n.UserId == id).Select(i => i.Book).ToListAsync(); // TODO: Почему n и i?
        }

        public async Task<Book> GetBook(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(b =>
                b.Id == id); // TODO:  Что ещё можно сделать кроме того, чтобы вернуть нул, если ничего не нашлось? Какой способ лучше или хуже?
        }

        //        public async Task<SelectedBook> Selected(SelectedBook selectedBook)
        //        {
        //            await _context.SelectedBooks.AddAsync(selectedBook);
        //            await _context.SaveChangesAsync();
        //
        //            return selectedBook;
        //        }

        public async Task<bool>
            IsSelectedBook(int userId,
                int bookId) // TODO: Мне по имени метода кажется, что этот он используется примерно так - если вернул, значит книга выбрана, если не вернул, значит не выбрана. Может, возвращать bool из него?
        {
            return await _context.SelectedBooks.AnyAsync(b => b.UserId == userId && b.BookId == bookId);
        }

        public void AddStarredBook(SelectedBook selectedBook) // TODO: Странное название метода
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