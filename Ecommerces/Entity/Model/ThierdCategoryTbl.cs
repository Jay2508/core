using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerces.Entity.Model
{
    [Table("ThierdCategoryTbl")]
    public class ThierdCategoryTbl
    {
        [Key]
        public int ThierdCatId { get; set; }
        public int CatId { get; set; }
        public int SubCatId { get; set; }
        public string ThirdCategory { get; set; }
        public string Icon { get; set; }
        public string Status { get; set; }
    }
}
