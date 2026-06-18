using System.ComponentModel.DataAnnotations;

namespace InvoiceProcessingAPI.Models
{
    public class Invoice
    {
        public int Id {     get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Range(1, 1000000)]
        public decimal Amount { get; set; }
        [Required]
        public string Status { get; set; }


    }
}
