namespace DailyNeeds1.DTO
{
    public class ProductCartDTO
    {
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public decimal OfferPercentage { get; set; }
        public int Quantity { get; set; }
    }
}
