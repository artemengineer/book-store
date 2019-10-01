using System.Collections.Generic;

namespace BookStoreAPI.EntityFramework.Models
{
    
    public class Book
    {
        public Book()
        {
            SelectedBooks = new HashSet<SelectedBook>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public ICollection<SelectedBook> SelectedBooks { get; set; }
    }
}