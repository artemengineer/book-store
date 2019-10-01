using System.Threading.Tasks;
using BookStoreAPI.EntityFramework.Models;

namespace BookStoreAPI.Services
{
    public interface IAuthService
    {
        Task<User> Login(string username, string password);
    }
}