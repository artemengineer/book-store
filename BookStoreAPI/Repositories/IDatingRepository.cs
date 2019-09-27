using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreAPI.Models;

namespace BookStoreAPI.Repositories
{
    public interface IDatingRepository
    {
        Task<List<Book>> GetBooks();
        Task<List<Book>> GetSelectedBooks(int id);
        Task<Book> GetBook(int id);
        Task<SelectedBook> GetSelectedBook(int userId, int bookId);
        void Selected(SelectedBook selectedBook);
        void Delete(SelectedBook selectedBook);
    }
}