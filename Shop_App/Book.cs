using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_App
{
    class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public decimal Price { get; set; }

        public Book(int id, string title, string author, string genre, decimal price)
        {
            this.Id = id;
            this.Title = title;
            this.Author = author;
            this.Genre = genre;
            this.Price = price;
        }
    }
}
