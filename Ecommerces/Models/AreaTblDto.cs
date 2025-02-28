using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerces.Models
{
    public class AreaTblDto
    {
        public int AreaId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string Area { get; set; }
        public string Status { get; set; }

        public List<SelectListItem>? State { get; set; }
    }
}
