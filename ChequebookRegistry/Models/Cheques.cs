namespace ChequebookRegistry.Models
{
    public class Cheques
    {
        public int Id { get; set; }
        public int? Payee { get; set; }
        public double Amount { get; set; }
        public DateTime DateDue { get; set; }
        public string Justification { get; set; }
        public int? RelatedCustomer { get; set; }
    }
}
