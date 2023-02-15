using MeetDay.Aplicacion.Core.Interfaces;
using MeetDay.Dominio.Core.Dtos.Appointment;
using MeetDay.Dominio.Core.Entity;
using MeetDay.Dominio.Core.Interfaces.Repositories;

namespace MeetDay.Aplicacion.Core.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository<Appointment,int> _appointmentRepository;
        public AppointmentService(IAppointmentRepository<Appointment,int> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public Task<Appointment> Create(AppointmentDto appointmentDto)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(AppointmentDto appointmentDto)
        {
            throw new NotImplementedException();
        }
    }
}