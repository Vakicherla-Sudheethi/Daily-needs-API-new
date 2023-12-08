using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyNeeds1.Entities
{
    public class Login
    {
        [Key]
        [StringLength(10)]
        public int LoginId { get; set; }
        [Required]
        [StringLength(10)]
        [Column("Username", TypeName = "varchar")]
        public string Username { get; set; }

        [Required]
        [StringLength(8)]
        [Column("Password", TypeName = "varchar")]
        public string Password { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}
