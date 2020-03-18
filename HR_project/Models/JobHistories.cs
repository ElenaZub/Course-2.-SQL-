using System;
using System.Collections.Generic;

namespace HR_project.Models
{
    public class JobHistories
    {

        public DateTime StartDate { get; set; }

        public int EmployeesId { get; set; }

        public DateTime EndDate { get; set; }

        public Departments Departments { get; set; }

        public ICollection<Employees> Employees { get; set; }

        public string JobId { get; set; }

        public Jobs Jobs { get; set; }
    }
}
