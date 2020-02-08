﻿using System;
using System.Collections.Generic;

namespace Task1_DBFirst.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
