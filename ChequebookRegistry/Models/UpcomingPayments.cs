using System.ComponentModel.DataAnnotations;

namespace ChequebookRegistry.Models
{
    public class UpcomingPayments
    {
        [Key]
        public string PayeeName { get; set; }
        public double Amount { get; set; }
        public DateTime DateDue { get; set; }
    }
}
