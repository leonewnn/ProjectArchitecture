using System.ComponentModel.DataAnnotations;

namespace WebAPI_Printer.Models
{
    public class AddMoneyDto
    {
        public string? CardId { get; set; }
        public string? Username { get; set; }
        
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }
    }
}
