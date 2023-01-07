using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetDay.Dominio.Core.Entity
{
    [Table("document_management")]
    public class DocumentManagement
    {
        [Key]
        [Column(Order = 0)]
        public int CatalogDocumentId { get; set; }
        [Column(Order = 1)]
        public int ManagementId { get; set; }
    }
}