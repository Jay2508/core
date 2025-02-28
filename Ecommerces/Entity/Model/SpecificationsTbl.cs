using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommerces.Entity.Model
{
    [Table("SpecificationsTbl")]
    public class SpecificationsTbl
    {
        [Key]
        public int SpeId { get; set; }
        public string SpecificationName { get; set; }
        public string SpecificationType { get; set; }
        public string Status { get; set; }
    }
}
