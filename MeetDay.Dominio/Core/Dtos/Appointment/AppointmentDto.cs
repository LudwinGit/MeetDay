namespace MeetDay.Dominio.Core.Dtos.Appointment
{
    public class AppointmentDto
    {
        public int id { get; set; }
        public int gestionId { get; set; }
        public string Observation { get; set; }
        public int userId { get; set; }
        public string state { get; set; }
        public List<DocumentAppointmentDto> documents { get; set; }
    }
    public class DocumentAppointmentDto
    {
        public string file { get; set; }
        public string name { get; set; }
        public int MyProperty { get; set; }
    }
}