using System;
using System.Collections.Generic;

namespace HRwork.Models
{
    public partial class Employees
    {
        public Employees()
        {
            JobHistories = new HashSet<JobHistories>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public string JobsId { get; set; }
        public decimal Salary { get; set; }
        public decimal CommissionPct { get; set; }
        public int ManagerId { get; set; }
        public int? DepartmentsId { get; set; }

        public virtual Departments Departments { get; set; }
        public virtual Jobs Jobs { get; set; }
        public virtual ICollection<JobHistories> JobHistories { get; set; }
    }
}
