using System.Threading.Tasks;
using BookStoreAPI.EntityFramework.Models;

namespace BookStoreAPI.Repositories
{
    public interface IAuthRepository
    {
        Task<User> GetUser(string username);
        Task<User> Register(User user, string password);
        Task<bool> UserExists(string username);
    }
}