using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityWithNTierEcommerceDotNETCORE.Entity.Model
{
    [Table("StateTbl")]
    public class StateTbl
    {
        [Key]
        public int StateId { get; set; }
        public string State { get; set; }
        public string Status { get; set; }
    }
}
