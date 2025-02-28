using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerces.Entity.Model
{
    [Table("AreaTbl")]
    public class AreaTbl
    {
        [Key]
        public int AreaId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string Area { get; set; }
        public string Status { get; set; }
    }
}
