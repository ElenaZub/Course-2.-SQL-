using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binding_Task4
{
    public class Employee
    {
        private static int counter = 0;

        public int Id { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }

        public DateTime HiredDate { get; set; }

        public Boolean IsManager { get; set; }

        public Employee()
        {
            this.Id = counter++;
        }
    }
}
