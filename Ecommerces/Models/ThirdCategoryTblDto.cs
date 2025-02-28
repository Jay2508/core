using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerces.Models
{
    public class ThirdCategoryTblDto
    {
        public int ThierdCatId { get; set; }
        public int CatId { get; set; }
        public int SubCatId { get; set; }
        public string ThirdCategory { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string ThierdCategoryIcon { get; set; }
        public IFormFile Icon { get; set; }
      
    }
}
