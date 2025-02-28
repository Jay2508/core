using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerces.Models
{
    public class SubCategoryTblDto
    {
        public int SubCatId { get; set; }
        public int CatId { get; set; }
        public string SubCategory { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public string SubCategoryIcon { get; set; }
        public IFormFile Icon { get; set; }
        //public List<SelectListItem>? CategoryData { get; set; }    
    }
}
