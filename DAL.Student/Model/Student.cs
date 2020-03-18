using System;
using System.Collections.Generic;
using System.Text;

namespace DALStudent.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Course Course { get; set; }
    }
}