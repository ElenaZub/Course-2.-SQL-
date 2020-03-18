using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_project.Models
{
    public class Regions
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Countries> Countries { get; set; }
    }
}
