using System.Collections.Generic;
using System.Linq;
using BookStoreAPI.Models;
using Newtonsoft.Json;

namespace BookStoreAPI.Data
{
    public class Seed
    {
        public static void SeedUsers(DataBaseContext context)
        {
            if (!context.Users.Any())
            {
                var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                foreach (var user in users)
                {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash("123", out passwordHash, out passwordSalt);

                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    user.Username = user.Username.ToLower();
                    context.Users.Add(user);
                }

                context.SaveChanges();
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static void SeedBooks(DataBaseContext context)
        {
            if (!context.Books.Any())
            {
                var bookData = System.IO.File.ReadAllText("Data/BookSeedData.json");
                var books = JsonConvert.DeserializeObject<List<Book>>(bookData);
                foreach (var book in books)
                {
                    context.Books.Add(book);
                }

                context.SaveChanges();
            }
        }
    }
}