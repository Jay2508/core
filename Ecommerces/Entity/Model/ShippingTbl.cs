using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerces.Entity.Model
{
    [Table("ShippingTbl")]
    public class ShippingTbl
    {
        [Key]
        public int ShippingId { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string Pincode { get; set; }
        public string Locality { get; set; }
        public string LandMark { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string AlternativeMobile { get; set; }
        public string DeliveryAt { get; set; }
        public string RageDate { get; set; }
    }
}
