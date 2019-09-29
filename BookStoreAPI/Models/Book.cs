using System;
using System.Collections.Generic;

namespace BookStoreAPI.Models
{
    public class Book // TODO: ������ ����� Models �� ������ Data? �������� ��� ��� ���� �����-�� ���������� ���������?
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