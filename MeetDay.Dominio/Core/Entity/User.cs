using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetDay.Dominio.Core.Entity
{
    [Table("users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string Username { get; set; }
        [MaxLength(150)]
        public string Password { get; set; }
        [MaxLength(3)]
        public string Role { get; set; } = "USR";
        [MaxLength(100)]

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [MaxLength(3)]
        public string State { get; set; } = "ACT";
        public DateTime DateCreate { get; set; } = DateTime.Now;
        public DateTime DateUpdate { get; set; } = DateTime.Now;
    }
}