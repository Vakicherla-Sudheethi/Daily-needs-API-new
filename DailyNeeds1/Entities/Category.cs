using System;
using System.ComponentModel.DataAnnotations;

namespace DailyNeeds1.Entities
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }
    }
}

