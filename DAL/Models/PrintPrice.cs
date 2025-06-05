using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class PrintPrice
    {
//asfddf
        [Key]
        [MaxLength(10)]
        public string TypeCode { get; set; } = string.Empty;
        
        [Column(TypeName = "decimal(6,4)")]
        public decimal PricePerPage { get; set; }
    }
}