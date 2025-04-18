using System;

namespace ProjectArchitecture.Models
{
    public class PrintJob
    {
        public int PrintJobId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int PagesPrinted { get; set; }
        public decimal CostChf { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
