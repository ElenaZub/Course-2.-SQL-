using System;
using System.Collections.Generic;

namespace HRwork.Models
{
    public partial class Jobs
    {
        public Jobs()
        {
            Employees = new HashSet<Employees>();
            JobHistories = new HashSet<JobHistories>();
        }

        public string Id { get; set; }
        public string JobTitle { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<JobHistories> JobHistories { get; set; }
    }
}
