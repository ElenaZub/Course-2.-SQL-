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

        public Book(bool isNew, string title, decimal cost, DateTime date)
            : base()
        {
            //this.IsNew = isNew;
            this.Title = title;
            this.Cost = cost;
            this.Date = date;
        }

        public Book()
            : base(){}
    }
}
