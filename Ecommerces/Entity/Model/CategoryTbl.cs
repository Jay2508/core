using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerces.Entity.Model
{
    [Table("CategoryTbl")]
    public class CategoryTbl
    {
        [Key]
        public int CatId { get; set; }
        public required string Category { get; set; }
        public required string  icon { get; set; }
        public required string Status { get; set; }
    }
}
