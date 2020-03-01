using System.Collections.Generic;

namespace Movie_project.Models
{
    public class Director
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LasName { get; set; }

        public ICollection<MovieDirection> MovieDirections { get; set; }
    }
}