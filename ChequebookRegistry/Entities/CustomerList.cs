using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChequebookRegistry.Entities
{
    public class CustomerList
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<SelectListItem> Customers { get; set; }
    }
}
