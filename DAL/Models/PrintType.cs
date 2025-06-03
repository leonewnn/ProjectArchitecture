using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectArchitecture.Models
{
    public class PrintType
    {
        [Key] // Nécessaire car TypeCode n'est pas "Id" ou "PrintTypeId"
        public string TypeCode { get; set; }
        public decimal PricePerPage { get; set; }

        public List<PrintJob> PrintJobs { get; set; }
    }
}