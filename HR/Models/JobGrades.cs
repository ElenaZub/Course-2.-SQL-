using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HR.Models
{
    public class JobGrades
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [StringLength(21)]
        [Key]
        public string Id { get; set; }

        public decimal LowestSal { get; set; }

        public decimal HighestSal { get; set; }
    }
}
