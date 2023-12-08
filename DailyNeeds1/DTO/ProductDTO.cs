namespace DailyNeeds1.DTO
{
    public class ProductDTO
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public int CategoryID { get; set; }

        public int UserID { get; set; }

        public decimal Price { get; set; }

        public bool Availability { get; set; }

        public int CityId { get; set; }
        public int LocId { get; set; }
    }
}
