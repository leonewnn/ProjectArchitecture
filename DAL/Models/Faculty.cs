using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyId { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Name { get; set; } 
        
        // Navigation property
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}