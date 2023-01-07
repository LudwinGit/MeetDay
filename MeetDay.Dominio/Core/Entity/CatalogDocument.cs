using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetDay.Dominio.Core.Entity
{
    [Table("catalogDocuments")]
    public class CatalogDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(3)]
        public string State { get; set; } = "ACT";
        [MaxLength(1000)]
        public DateTime DateCreate { get; set; } = DateTime.Now;
        public DateTime DateUpdate { get; set; } = DateTime.Now;
    }
}