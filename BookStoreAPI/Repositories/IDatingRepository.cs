using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreAPI.EntityFramework.Models;

namespace BookStoreAPI.Repositories
{
    public interface IDatingRepository
    {
        Task<List<Book>> GetBooks();
        Task<List<Book>> GetSelectedBooks(int id);
        Task<Book> GetBook(int id);
        Task<bool> IsSelectedBook(int userId, int bookId);
        void AddStarredBook(SelectedBook selectedBook);
        void Delete(SelectedBook selectedBook);
    }
}