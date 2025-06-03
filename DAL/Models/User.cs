using System.Collections.Generic;

namespace ProjectArchitecture.Models
{
    public class User
    {
        public int UserId { get; set; } // Clé primaire par convention EF
        public string Uid { get; set; } // Identifiant métier/externe
        public string Username { get; set; }
        public string Password { get; set; }
        public int CardNumber { get; set; }
        public decimal Balance { get; set; }
        public string Role { get; set; }

        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        public List<Transaction> Transactions { get; set; }
        public List<PrintJob> PrintJobs { get; set; }
    }
}
