namespace Model.Entity
{
    public class OrderItem
    {
        public int Quantity { get; set; }
        public decimal ListPrice { get; set; }
        public decimal Discount { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}