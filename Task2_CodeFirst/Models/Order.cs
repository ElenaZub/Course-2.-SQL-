using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Task2_CodeFirst.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public  OrderStatus OrderStatus { get; set; }

        public int ItemsTotal { get; set; }

        public string Phone { get; set; }

        public string  DeleveryStreet { get; set; }

        public string  DeleveryCity { get; set; }

        public string  DeleveryZip { get; set; }

        public Customer Customer { get; set; }
    }
}
