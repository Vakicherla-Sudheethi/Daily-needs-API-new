using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyNeeds1.Entities
{
    public class Product
    {
       
        public int ProductID { get; set; }

        [Required]
        [StringLength(20)]
        public string ProductName { get; set; }

        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public Category Category { get; set; }

        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public bool Availability { get; set; }

        //[Required]
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }

        public int LocId { get; set; }
        [ForeignKey("LocId")]
        public Location Location { get; set; }

    }
}
