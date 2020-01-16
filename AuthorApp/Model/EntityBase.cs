using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorApp.Model
{
    public class EntityBase
    {
        public static int counter = 0;
        public int Id { get; set; }

        public bool IsNew { get; set; }

        public EntityBase()
        {
            this.IsNew = true;
            this.Id = counter++;
        }

        public void Save()
        {
            this.IsNew = false;
        }
    }
}
