namespace ChequebookRegistry.Models
{
    public class Payees
    {
        public int ID { get; set; }
        public string PayeeName { get; set; }
        public string ContactPerson { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public double TotalAmount { get; set; }
    }
}
