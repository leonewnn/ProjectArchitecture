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
       
        [Display(Name = "Amount (CHF)")]
        public decimal Amount { get; set; }
    }
}