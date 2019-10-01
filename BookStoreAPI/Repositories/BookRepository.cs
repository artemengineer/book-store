using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreAPI.EntityFramework;
using BookStoreAPI.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repositories
{
    // TODO: Dating?
    /**
     * Answer:
     * Да тут лучше было назвать BookRepository
     */
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

        // TODO: Может, лучше userId параметр?
        /**
         * Answer:
         * Да, userId правильней использовать, спешил решил упростить.
         */
        public async Task<List<Book>> GetSelectedBooks(int userId)
        {
            return await _context.SelectedBooks.Where(sb => sb.UserId == userId).Select(sb => sb.Book).ToListAsync();
        }

        // TODO:  Что ещё можно сделать кроме того, чтобы вернуть нул, если ничего не нашлось? Какой способ лучше или хуже?
        /**
         * Answer:
         * Тут я не понял, ты имеешь ввиду что можно кинуть исключение, а выше его отловить, что также будет показывать что обьекта нет?
         */
        public async Task<Book> GetBook(int bookId)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.Id == bookId);
        }

        // TODO: Мне по имени метода кажется, что этот он используется примерно так - если вернул, значит книга выбрана, если не вернул, значит не выбрана. Может, возвращать bool из него?
        /**
         * Answer:
         * Поменял название и переделал логику на возврат bool, да так лучше
         */
        public async Task<bool> IsSelectedBook(int userId, int bookId)
        {
            return await _context.SelectedBooks.AnyAsync(sb => sb.UserId == userId && sb.BookId == bookId);
        }

        // TODO: Странное название метода
        /**
         * Answer:
         * Поменял название
         */
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