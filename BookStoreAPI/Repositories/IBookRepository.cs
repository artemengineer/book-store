using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreAPI.EntityFramework.Models;

namespace BookStoreAPI.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBooks();
        Task<List<Book>> GetSelectedBooks(int userId);
        Task<Book> GetBook(int bookId);
        Task<bool> IsSelectedBook(int userId, int bookId);
        void AddSelectedBook(SelectedBook selectedBook);
        void Delete(SelectedBook selectedBook);
    }
}