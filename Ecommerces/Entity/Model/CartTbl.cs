using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityWithNTierEcommerceDotNETCORE.Entity.Model
{
    [Table("CartTbl")]
    public class CartTbl
    {
        [Key]
        public int CartId { get; set; }
        public int UniqeId { get; set; }
        public int ProductId { get; set; }
        public int Quntity { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
