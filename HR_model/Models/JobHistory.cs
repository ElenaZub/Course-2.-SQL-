using HR_model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HR.Models
{
    public class JobHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int EmployeeId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [StringLength(20)]
        public Jobs Jobs { get; set; }

        public Departments Departments { get; set; }

        public ICollection<Employees> Employees { get; set; }
    }
}