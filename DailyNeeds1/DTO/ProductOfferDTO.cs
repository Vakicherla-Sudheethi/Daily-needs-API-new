namespace DailyNeeds1.DTO
{
    public class ProductOfferDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal OfferPercentage { get; set; }
        public int LocId { get; set; }
    }
}
