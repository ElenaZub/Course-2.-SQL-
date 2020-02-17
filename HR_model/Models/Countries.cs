using HR.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HR_model.Models
{
    public class Countries
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [StringLength(2)]
        public int Id { get; set; }

        [MaxLength(40)]
        public string Name { get; set; }

        public Regions Regions { get; set; }

        public ICollection<Locations> Locations { get; set; }
    }
}