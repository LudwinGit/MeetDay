using System.ComponentModel.DataAnnotations;
using MeetDay.Dominio.Core.Dtos.Catolog;

namespace MeetDay.Dominio.Core.Dtos.Management
{
    public class ManagementDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese el nombre.")]
        [StringLength(150)]
        public string Name { get; set; }
        public string State { get; set; }
        [StringLength(1000)]
        public string Observation { get; set; }
        public List<OptionDto> Documents { get; set; } = new List<OptionDto>();
    }
}