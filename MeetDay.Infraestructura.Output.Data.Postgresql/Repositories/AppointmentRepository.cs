using MeetDay.Dominio.Core.Entity;
using MeetDay.Dominio.Core.Interfaces;
using MeetDay.Dominio.Core.Interfaces.Repositories;
using MeetDay.Infraestructura.Output.Data.Postgresql.Contexts;

namespace MeetDay.Infraestructura.Output.Data.Postgresql.Repositories
{
    public class AppointmentRepository : IAppointmentRepository<Appointment, int>
    {
        private readonly MeetDayContext _context;
        private readonly string _connectionString;
        public AppointmentRepository(MeetDayContext context, IGetConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString();
            _context = context;
        }
        public async Task<Appointment> AddAsync(Appointment entity)
        {
            await _context.Appointments.AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public int Edit(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}