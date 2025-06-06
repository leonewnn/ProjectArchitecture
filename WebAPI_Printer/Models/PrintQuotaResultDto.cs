using System.Collections.Generic;

namespace WebAPI_Printer.Models
{
    public class PrintQuotaResultDto
    {
        public string UserId { get; set; }
        public decimal QuotaChf { get; set; }
        public List<FormatPagesDto> Formats { get; set; }
    }
}
