using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetDay.Dominio.Core.Entity
{
    [Table("document_management")]
    public class DocumentManagement
    {
        [Key]
        [Column("catalogdocumentid", Order = 0)]
        public int CatalogDocumentId { get; set; }
        [Column("managementid", Order = 1)]
        public int ManagementId { get; set; }
    }
}