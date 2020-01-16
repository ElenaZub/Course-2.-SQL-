using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorApp.Model
{
    public class Book : EntityBase
    {
        public String Title { get; set; }

        public decimal Cost { get; set; }

        public DateTime Date { get; set; }

        public bool IsRead{ get; set; }

        public Language Language { get; set; }

        public Book(string title, decimal cost, DateTime date, bool isNew  = true, Language language=Language.Ukrainian)
        {
            this.Title = title;
            this.Cost = cost;
            this.Date = date;
            this.IsNew = isNew;
            this.Language = language;
        }

        public Book() { }
    }
}
