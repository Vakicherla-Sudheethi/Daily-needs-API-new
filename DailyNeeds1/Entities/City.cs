using System.ComponentModel.DataAnnotations;

namespace DailyNeeds1.Entities
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        public string CityName { get; set; }
    }
}
