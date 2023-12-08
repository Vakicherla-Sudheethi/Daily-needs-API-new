using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyNeeds1.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        [StringLength(50)]
        [Column("Username", TypeName = "varchar")]
        public string Username { get; set; }
        [Required]
        [StringLength(20)]
        [Column("Email", TypeName = "varchar")]
        public string Email { get; set; }
        [Required]
        [StringLength(8)]
        [Column("Password", TypeName = "varchar")]
        public string Password { get; set; }

        [ForeignKey("Role")]
        [StringLength(10)]
        public int RoleID { get; set; }

        public Role Role { get; set; }
    }
}
