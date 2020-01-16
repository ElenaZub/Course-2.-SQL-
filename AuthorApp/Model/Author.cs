using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;

namespace AuthorApp.Model
{
    public class Author : EntityBase
    {        
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public Country Country { get; set; }

        public Language Language { get; set; }

        public String PlaceOfBirth { get; set; }

        public ObservableCollection<Book> BooksList { get; set; }

        public Author(string firstName, string lastName, DateTime birthDate, Country country, Language language, string placeOfBirth, ObservableCollection<Book> bookList, bool isNew = true )
            :base() 
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.Country = country;
            this.Language = language;
            this.PlaceOfBirth = placeOfBirth;
            this.BooksList = bookList;
            this.IsNew = isNew;
        }

        public Author()
        {
            this.BooksList = new ObservableCollection<Book>();
        }

        public override string ToString()
        {
            return (this.FirstName + " " + this.LastName);
        }
    }
}
