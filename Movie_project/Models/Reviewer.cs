using System.Collections.Generic;

namespace Movie_project.Models
{
    public class Reviewer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Rating> Ratings { get; set; }
    }
}