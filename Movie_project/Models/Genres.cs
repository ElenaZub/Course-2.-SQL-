using System.Collections.Generic;

namespace Movie_project.Models
{
    public class Genres
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<MovieGenres> MovieGenres { get; set; }
    }
}