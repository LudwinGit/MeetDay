using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetDay.Dominio.Core.Entity
{
    [Table("users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        [Column("firstname")]
        public string FirstName { get; set; }
        [MaxLength(50)]
        [Column("lastname")]
        public string LastName { get; set; }
        [MaxLength(50)]
        [Column("username")]
        public string Username { get; set; }
        [MaxLength(150)]
        [Column("password")]
        public string Password { get; set; }
        [MaxLength(3)]
        [Column("role")]
        public string Role { get; set; } = "USR";
        [MaxLength(100)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Column("email")]
        public string Email { get; set; }
        [MaxLength(3)]
        [Column("state")]
        public string State { get; set; } = "ACT";
        [Column("date_created")]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [Column("date_update")]
        public DateTime DateUpdate { get; set; } = DateTime.Now;
    }
}