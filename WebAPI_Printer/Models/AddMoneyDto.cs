using System.ComponentModel.DataAnnotations;

namespace WebAPI_Printer.Models
{
    public class AddMoneyDto
    {
        public string? CardId { get; set; }
        public string? Username { get; set; }
        
        [Required]
        public decimal Amount { get; set; }
    }
}
