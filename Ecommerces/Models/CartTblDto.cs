namespace Ecommerces.Models
{
    public class CartTblDto
    {
        public int CartId { get; set; }
        public int UniqeId { get; set; }
        public int ProductId { get; set; }
        public int Quntity { get; set; }
        public DateTime EntryDate { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
