using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class User
    {
        [Key]
        public string Uid { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        public string Username { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(50)]
        public string CardId { get; set; } = string.Empty;
        
        public int FacultyId { get; set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal QuotaChf { get; set; }
        
        // Navigation property
        public virtual Faculty Faculty { get; set; } = null!;
    }
}