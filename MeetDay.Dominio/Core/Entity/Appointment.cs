using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetDay.Dominio.Core.Entity
{
    [Table("appointment")]
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("gestionid")]
        public int GestionId { get; set; }
        [Column("observation")]
        public string Observation { get; set; }
        [Column("userid")]
        public int UserId { get; set; }
        [Column("state")]
        [MaxLength(3)]
        public string State { get; set; } = "ACT";
        [Column("date_created")]
        public DateTime DateCreate { get; set; } = DateTime.Now;
        [Column("date_updated")]
        public DateTime DateUpdate { get; set; } = DateTime.Now;
    }
}