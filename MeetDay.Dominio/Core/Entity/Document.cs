using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetDay.Dominio.Core.Entity
{
    [Table("document")]
    public class Document
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("document64")]
        public string Document64 { get; set; }
        [MaxLength(150)]
        [Column("name")]
        public string Name { get; set; }
        [Column("date_created")]
        public DateTime DateCreate { get; set; } = DateTime.Now;
    }
}