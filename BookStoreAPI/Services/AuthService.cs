using System.Threading.Tasks;
using BookStoreAPI.EntityFramework.Models;
using BookStoreAPI.Repositories;

namespace BookStoreAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repo;

        public AuthService(IAuthRepository repo)
        {
            _repo = repo;
        }

        
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var tempHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < tempHash.Length; i++)
                {
                    if (tempHash[i] != passwordHash[i]) return false;
                }

                return true;
            }
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _repo.GetUser(username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }
    }
}