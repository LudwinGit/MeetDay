using MeetDay.Dominio.Core.Dtos.Appointment;
using MeetDay.Dominio.Core.Entity;

namespace MeetDay.Aplicacion.Core.Interfaces
{
    public interface IAppointmentService
    {
        Task<Appointment> Create(AppointmentDto appointmentDto);
        Task<int> Update(AppointmentDto appointmentDto);
        List<Appointment> GetAll();
        Task<Appointment> GetById(int id);
    }
}