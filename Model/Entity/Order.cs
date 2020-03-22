using System;
using System.Collections.Generic;

namespace Model.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }
        
        public int StaffId { get; set; }
        public Staff Staff { get; set; }
        
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}