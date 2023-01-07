using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MeetDay.Dominio.Core.Dtos.Catolog;
using MeetDay.Dominio.Core.Dtos.Management;

namespace MeetDay.Dominio.Core.Entity
{
    [Table("managements")]
    public class Management
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [MaxLength(150)]
        [Column("name")]
        public string Name { get; set; }
        [MaxLength(3)]
        [Column("state")]
        public string State { get; set; } = "ACT";
        [MaxLength(1000)]
        [Column("observation")]
        public string Observation { get; set; }
        [Column("date_create")]
        public DateTime DateCreate { get; set; } = DateTime.Now;
        [Column("date_update")]
        public DateTime DateUpdate { get; set; } = DateTime.Now;
        [NotMapped]
        public List<OptionDto> Documents { get; set; }
    }
}