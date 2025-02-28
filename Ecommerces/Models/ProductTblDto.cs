using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerces.Models
{
    public class ProductTblDto
    {
    
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ProPrice { get; set; }
        public int CatId { get; set; }
        public int SubCatId { get; set; }
        public int ThierdCatId { get; set; }
        public int BrandId { get; set; }
        public string ProPhoto { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public IFormFile? Photo { get; set; }
        public string Brand { get; set; }

        public string ThirdCategory { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
    }
}
