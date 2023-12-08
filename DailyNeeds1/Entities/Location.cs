using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DailyNeeds1.Entities
{
    public class Location
    {
        [Key]
        public int LocId { get; set; }
        [Required]
        public string LocName { get; set; }
        [Required]
        public int CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public City City { get; set; }
    }
}