namespace Ecommerces.Models
{
    public class OrderTbl
    {
        public int OrderId { get; set; }
        public string BillNo { get; set; }
        public int ShippingId { get; set; }
        public int RegId { get; set; }
        public string Amount { get; set; }
        public int Qty { get; set; }
        public string PayStatus { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
