using System;
using System.Collections.Generic;

namespace HRwork.Models
{
    public partial class Departments
    {
        public Departments()
        {
            Employees = new HashSet<Employees>();
            JobHistories = new HashSet<JobHistories>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ManagersId { get; set; }
        public int? LocationsId { get; set; }

        public virtual Locations Locations { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<JobHistories> JobHistories { get; set; }
    }
}
