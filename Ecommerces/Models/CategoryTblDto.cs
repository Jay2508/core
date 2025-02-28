namespace Ecommerces.Models
{
    public class CategoryTblDto
    {
        public int CatId { get; set; }
        public string Category { get; set; }
        public string CategoryIcon { get; set; }
        public IFormFile Icon { get; set; }
        public string Status { get; set; }
    }
}
