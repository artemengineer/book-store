using System.Collections.Generic;

namespace BookStoreAPI.EntityFramework.Models
{
    public class User
    {
        public User()
        {
            SelectedBooks = new HashSet<SelectedBook>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<SelectedBook> SelectedBooks { get; set; }
    }
}