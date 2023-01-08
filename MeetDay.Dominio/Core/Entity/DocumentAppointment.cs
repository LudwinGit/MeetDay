using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetDay.Dominio.Core.Entity
{
    [Table("document_appointment")]
    public class DocumentAppointment
    {
        [Key]
        [Column("document_id", Order=0)]
        public int DocumentId { get; set; }
        [Key]
        [Column("catalogdocument_id", Order=1)]
        public int CatalogDocumentId { get; set; }
        [Key]
        [Column("appointment_id", Order=2)]
        public int AppointmentId { get; set; }
        [Column("date_created")]
        public DateTime DateCreate { get; set; } = DateTime.Now;
    }
}