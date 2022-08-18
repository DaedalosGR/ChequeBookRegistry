using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChequebookRegistry.Models
{
    public class Customers
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public double TotalAmount { get; set; }
    }
}
