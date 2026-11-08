namespace University_Cafeteria_2.Models
{
    public class Category_model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product_model> Productmodel { get; set; }
    }
}
