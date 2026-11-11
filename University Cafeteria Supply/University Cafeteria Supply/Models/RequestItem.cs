namespace University_Cafeteria_Supply.Models
{
    public class RequestItem
    {
         public string Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public int ProductId { get; set; }
        public int SupplyRequestId { get; set; }
        public Product Product { get; set; }
        public SupplyRequest SupplyRequest { get; set; }
    }
}
