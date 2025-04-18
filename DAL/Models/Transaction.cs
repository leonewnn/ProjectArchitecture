using System;

namespace ProjectArchitecture.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public string Type { get; set; } // RECHARGE, PRINT, etc.
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
