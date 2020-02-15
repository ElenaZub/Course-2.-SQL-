using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRwork.Models
{
    public class Locations
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(25)]
        public string StreetAddress { get; set; }

        [MaxLength(12)]
        public string PostalCode { get; set; }

        [MaxLength(30)]
        public string City { get; set; }

        [MaxLength(12)]
        public string StateProvince { get; set; }

        public Countries Countries { get; set; }

        public ICollection<Departments> Departments { get; set; }
    }
}
