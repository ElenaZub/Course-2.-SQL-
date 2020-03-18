using System;
using System.Collections.Generic;
using System.Text;

namespace DALStudent.Model
{
    public class Department
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}