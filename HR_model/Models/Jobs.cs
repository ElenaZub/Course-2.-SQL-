using HR.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HR_model.Models
{
    public class Jobs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(10)]
        public string Id { get; set; }

        [MaxLength(35)]
        public string JobTitle { get; set; }

        public decimal MinSalary { get; set; }

        public decimal MaxSalary { get; set; }

        public ICollection<JobHistory> JobHistories { get; set; }

        public ICollection<Employees> Employees { get; set; }
    }
}