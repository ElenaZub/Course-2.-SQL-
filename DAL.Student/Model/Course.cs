using System;
using System.Collections.Generic;
using System.Text;

namespace DALStudent.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public override string ToString()
        {
            return $"{this.Id} - {this.Name}";
        }
    }
}