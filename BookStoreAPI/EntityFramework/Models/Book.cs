using System.Collections.Generic;

namespace BookStoreAPI.EntityFramework.Models
{
    // TODO: Почему папка Models не внутри Data? Рандомно или тут есть какая-то интересная философия?
    /**
     * Answer:
     * Переименовал папку Data в папку EntityFramework, в которую перенес модели и логику DbContext 
     */
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