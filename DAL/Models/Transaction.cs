using System;

namespace ProjectArchitecture.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        // Changement : string UserId -> int UserId pour suivre les conventions EF
        public int UserId { get; set; }
        public User User { get; set; }

        public string TypeCode { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
