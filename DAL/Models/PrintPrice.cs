using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class PrintPrice
    {
//asfddfqwrestddwe
        [Key]
        [MaxLength(10)]
        public string TypeCode { get; set; } 
        
        [Column(TypeName = "decimal(6,4)")]
        public decimal PricePerPage { get; set; }
    }
}