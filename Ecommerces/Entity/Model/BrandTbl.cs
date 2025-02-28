using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerces.Entity.Model
{
    [Table("BrandTbl")]
    public class BrandTbl
    {
        [Key]
        public int BrandId { get; set; }
        public string Brand { get; set; }
        public  string icon { get; set; }

        public string Status { get; set; }
    }
}
