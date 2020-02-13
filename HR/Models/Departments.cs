using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HR.Models
{
    public class Departments
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        public int ManagersId { get; set; }

        public ICollection<Employees> Employees { get; set; }

        public Locations Locations { get; set; }

        public ICollection<JobHistory> JobHistories { get; set; }


    }
}
