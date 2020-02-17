using System;
using System.Collections.Generic;

namespace HR_project.Models
{
    public class Departments
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ManagersId { get; set; }

        public int LocationsId { get; set; }

        public Locations Locations { get; set; }

        public ICollection<Employees> Employees { get; set; }

        public ICollection<JobHistories> JobHistories { get; set; }
    }
}
