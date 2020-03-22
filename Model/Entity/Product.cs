using System;
using System.Collections.Generic;

namespace Model.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ModelYear { get; set; }
        public decimal ListPrice { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Stock> Stocks { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}