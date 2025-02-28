using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerces.Models
{
    public class CityTbl
    {
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string City { get; set; }
        public string Status { get; set; }

        public List<SelectListItem>? State { get; set; }
    }
}
