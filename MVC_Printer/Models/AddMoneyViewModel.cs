using System.ComponentModel.DataAnnotations;

namespace MVC_Printer.Models
{
    public class AddMoneyViewModel
    {
        [Display(Name = "Card ID")]
        public string? CardId { get; set; }

        [Display(Name = "Username")]
        public string? Username { get; set; }

        [Required]
        [Range(0.01, 1000.00, ErrorMessage = "Amount must be between 0.01 and 1000.00")]
        [Display(Name = "Amount (CHF)")]
        public decimal Amount { get; set; }
    }
}