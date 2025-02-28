using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerces.Entity.Model
{
    [Table("SubCategoryTbl")]
    public class SubCategoryTbl
    {
        [Key]
        public int SubCatId { get; set; }
        public int CatId { get; set; }
        public string SubCategory { get; set; }
   
        public required string Icon { get; set; }

        public string Status { get; set; }
    }
}
