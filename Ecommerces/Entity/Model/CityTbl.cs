using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityWithNTierEcommerceDotNETCORE.Entity.Model
{
    [Table("CityTbl")]
    public class CityTbl
    {
        [Key]
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string City { get; set; }
        public string Status { get; set; }
    }
}
