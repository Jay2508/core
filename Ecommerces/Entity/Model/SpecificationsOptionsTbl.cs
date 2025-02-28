using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerces.Entity.Model
{
    [Table("SpecificationsOptionsTbl")]
    public class SpecificationsOptionsTbl
    {
        [Key]
        public int SpecificationsId { get; set; }
        public int SpeId { get; set; }
        public string Value { get; set; }
        public string Status { get; set; }
    }
}
