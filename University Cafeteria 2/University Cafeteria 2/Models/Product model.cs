namespace University_Cafeteria_2.Models
{
    public class Product_model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public double Quantity { get; set; }
        public int Category_modelId { get; set; }
        public Category_model Category_model { get; set; }
        public int Supplier_modelId { get; set; }
        public Supplier_model Supplier_model { get; set; }
    }
}
