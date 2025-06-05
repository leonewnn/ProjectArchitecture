namespace MVC_Printer.Models
{
    public class PrintQuotaViewModel
    {
        public string UserId { get; set; } = string.Empty;
        public decimal QuotaChf { get; set; }
        public List<FormatPagesViewModel> Formats { get; set; } = new();
    }

    public class FormatPagesViewModel
    {
        public string TypeCode { get; set; } = string.Empty;
        public int PagesAvailable { get; set; }
    }
}