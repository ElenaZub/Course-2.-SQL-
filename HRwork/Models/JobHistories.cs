using System;
using System.Collections.Generic;

namespace HRwork.Models
{
    public partial class JobHistories
    {
        public DateTime StartDate { get; set; }
        public int? EmployeesId { get; set; }
        public DateTime EndDate { get; set; }
        public string JobsId { get; set; }
        public int? DepartmentsId { get; set; }

        public virtual Departments Departments { get; set; }
        public virtual Employees Employees { get; set; }
        public virtual Jobs Jobs { get; set; }
    }
}
