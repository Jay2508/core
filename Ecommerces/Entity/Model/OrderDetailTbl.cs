using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace   Ecommerces.Entity.Model
{
    [Table("OrderDetailTbl")]
    public class OrderDetailTbl
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
