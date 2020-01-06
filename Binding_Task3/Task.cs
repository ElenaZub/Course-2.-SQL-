using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binding_Task3
{
    public class Task
    {
        private static int counter = 1;

        public int Id { get; }
        public String Name { get; set; }

        public String Description { get; set; }

        public int Priority { get; set; }

        public Task()
        {
            this.Id = counter++;
        }
    }
}
