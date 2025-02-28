using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerces.Entity.Model
{
    [Table("ProductTbl")]
    public class ProductTbl
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CatId { get; set; }
        public int SubCatId { get; set; }
        public int ThierdCatId { get; set; }
        public int BrandId { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
