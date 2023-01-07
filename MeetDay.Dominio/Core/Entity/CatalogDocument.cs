using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetDay.Dominio.Core.Entity
{
    [Table("catalog_documents")]
    public class CatalogDocument
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
        [Column("date_create")]
        public DateTime DateCreate { get; set; } = DateTime.Now;
        [Column("date_update")]
        public DateTime DateUpdate { get; set; } = DateTime.Now;
    }
}