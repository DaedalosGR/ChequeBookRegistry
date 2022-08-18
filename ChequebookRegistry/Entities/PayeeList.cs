using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChequebookRegistry.Entities
{
    public class PayeeList
    {
        public int ID { get; set; }
        public string PayeeName { get; set; }
        public List<SelectListItem> Customers { get; set; }
    }
}
