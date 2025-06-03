using System;

namespace ProjectArchitecture.Models
{
    public class PrintJob
    {
        public int PrintJobId { get; set; }
        // Changement : string UserId -> int UserId pour suivre les conventions EF
        public int UserId { get; set; }
        public User User { get; set; }

        public int PagesPrinted { get; set; }
        public decimal CostChf { get; set; }
        public DateTime Date { get; set; }
        public string TypeCode { get; set; }
        public string Description { get; set; }

        public PrintType PrintType { get; set; }
    }
}
