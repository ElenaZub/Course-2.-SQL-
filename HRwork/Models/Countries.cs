using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRwork.Models
{
    public class Countries
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Regions Regions { get; set; }

        public ICollection<Locations> Locations { get; set; }
    }
}
