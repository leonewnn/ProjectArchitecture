namespace MVC_Printer.Models
{
    public class UserBalanceViewModel
    {
        public string Uid { get; set; } = "";
        public string Username { get; set; } = "";
        public decimal Balance { get; set; }
        public bool IsSelected { get; set; }
    }
}