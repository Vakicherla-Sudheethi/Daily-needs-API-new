using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace DailyNeeds1.Entities
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }

        [Required]
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }

        [Required]

        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
