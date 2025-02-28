namespace Ecommerces.Models
{
    public class OrderDetailTblDto
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public decimal TotalPrice { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string BillNo { get; set; }
        public DateTime OrderDate { get; set; }
        public int Pincode { get; set; }
        public string ProductName { get; set; }
    }
}
