using System;
using System.Collections.Generic;

namespace Movie_project.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public int Time { get; set; }

        public string Lang { get; set; }

        public DateTime DtRel { get; set; }

        public string RelCountry { get; set; }

        public ICollection<MovieDirection> MovieDirections { get; set; }

        public ICollection<MovieGenres> MovieGenres { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public ICollection<MovieCast> MovieCasts { get; set; }
    }
}