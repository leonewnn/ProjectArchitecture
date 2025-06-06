namespace MVC_Printer.Models
{
    public class AddQuotaToFacultyViewModel
    {
        public int FacultyId { get; set; }
        public string FacultyName { get; set; } = "";
        public decimal Amount { get; set; }
        public List<UserBalanceViewModel> Users { get; set; } = new();
        public List<string> SelectedUsernames { get; set; } = new();
    }
}