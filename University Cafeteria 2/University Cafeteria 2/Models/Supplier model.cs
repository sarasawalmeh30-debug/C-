namespace University_Cafeteria_2.Models
{
    public class Supplier_model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<Product_model> Productmodel { get; set; }
    }
}
