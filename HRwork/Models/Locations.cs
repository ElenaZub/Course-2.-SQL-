using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRwork.Models
{
    public class Locations
    {
        public int Id { get; set; }

        public string StreetAddress { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string StateProvince { get; set; }

        public Countries Countries { get; set; }

        public ICollection<Departments> Departments { get; set; }
    }
}
