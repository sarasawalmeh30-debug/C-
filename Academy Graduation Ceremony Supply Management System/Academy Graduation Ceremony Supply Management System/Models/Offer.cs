namespace Academy_Graduation_Ceremony_Supply_Management_System.Models
{
    public class Offer
    {
        public string SupplierName { get; set; }
        public string OfferName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Category { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
