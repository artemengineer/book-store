using System;
using System.Collections.Generic;

namespace BookStoreAPI.Models
{
    public class Book // TODO: Почему папка Models не внутри Data? Рандомно или тут есть какая-то интересная философия?
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