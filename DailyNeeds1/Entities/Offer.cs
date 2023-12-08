using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace DailyNeeds1.Entities
{
    public class Offer
    {
        
        public int OfferId { get; set; }
        [Required]
        public int ProductID { get; set; }

        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal OfferPercentage { get; set; }

    }
}
