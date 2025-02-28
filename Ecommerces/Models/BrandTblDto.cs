namespace Ecommerces.Models
{
    public class BrandTblDto
    {
        public int BrandId { get; set; }
        public string Brand { get; set; }
        public string BrandIcon { get; set; }
        public IFormFile Icon { get; set; }
        public string Status { get; set; }
    }
}
