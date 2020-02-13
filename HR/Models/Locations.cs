using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HR.Models
{
    public class Locations
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(25)]
        public string StreetAddress { get; set; }

        [StringLength(12)]
        public string PostalCode { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        [StringLength(22)]
        public string StateProvince { get; set; }

        [StringLength(2)]
        public Countries Countries { get; set; }

        public ICollection<Departments> Departments { get; set; }
    }
}
