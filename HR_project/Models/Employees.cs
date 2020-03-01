using System;
using System.Collections.Generic;

namespace HR_project.Models
{
    public class Employees
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime HireDate { get; set; }

        public decimal Salary { get; set; }

        public decimal CommissionPct { get; set; }

        public int ManagerId { get; set; }
        public Departments Departments { get; set; }

        public string JobsId { get; set; }

        public Jobs Jobs { get; set; }

        public JobHistories JobHistories { get; set; }
    }
}
