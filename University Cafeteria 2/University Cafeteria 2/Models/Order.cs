namespace University_Cafeteria_2.Models
{
    public class Order
    {	



        public int Id { get; set; }
        public string CustomerName { get; set; }
        public double TotalPrice { get; set; }
        public string Status {  get; set; }

        public DateTime OrderDate {  get; set; }
        public int EmployeeId {  get; set; }
        public Employee employee { get; set; }

    }
}
