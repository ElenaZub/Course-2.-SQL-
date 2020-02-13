﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HR.Models
{
    public class Countries
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public Regions Regions { get; set; }

        public ICollection<Locations> Locations { get; set; }
    }
}
