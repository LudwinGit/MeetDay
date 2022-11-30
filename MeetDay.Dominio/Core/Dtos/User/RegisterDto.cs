using System.ComponentModel.DataAnnotations;

namespace MeetDay.Dominio.Core.Dtos.User
{
    public class RegisterDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ingrese el primer nombre.")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Ingrese el primer apellido.")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Ingrese el usuario.")]
        [StringLength(50)]
        public string Username { get; set; }
        [Required(ErrorMessage ="Ingrese la contraseña.")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Ingrese el correo.")]
        [EmailAddress(ErrorMessage ="Correo invalido.")]
        public string Email { get; set; }
    }
}