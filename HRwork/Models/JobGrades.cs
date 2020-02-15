using System;
using System.Collections.Generic;

namespace HRwork.Models
{
    public partial class JobGrades
    {
        public string Id { get; set; }
        public decimal LowestSal { get; set; }
        public decimal HighestSal { get; set; }
    }
}
