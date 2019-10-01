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

        // TODO: Я бы поднял этот метод вверх, чтобы он был над публичными. 
        // TODO: что-то слишком умно для репозитория. Он же по хорошему должен просто с данными работать? Или тут что-то другое задумано?
        /**
         * Answer:
         * Создал класс AuthService, перенес сюда логику с контролера AuthController для логина
         * По хорошему почти всегда нужна прослойка Контролер -> Сервис(для логики) -> Репозиторий(для работы с базой)
         * Вначале я это не делал сервис исходя, что это тестовый, но для примера сделал сервис с 1 методом, ну чтобы ты понимал, что я это понимаю :)
         */
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