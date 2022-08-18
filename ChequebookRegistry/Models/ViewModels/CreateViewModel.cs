using Microsoft.AspNetCore.Mvc.Rendering;
namespace ChequebookRegistry.Models.ViewModels
{
    public class CreateViewModel
    {
        public int Id { get; set; }
        public int? Payee { get; set; }
        public double Amount { get; set; }
        public DateTime DateDue { get; set; }
        public string Justification { get; set; }
        public int? RelatedCustomer { get; set; }
        public List<SelectListItem> CustomersList { get; set; }
        public List<SelectListItem> PayeesList { get; set; }
    }
}
