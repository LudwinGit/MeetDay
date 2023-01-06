using MeetDay.Dominio.Core.Entity;
using MeetDay.Dominio.Core.Interfaces.Repositories;
using MeetDay.Infraestructura.Output.Data.Postgresql.Contexts;

namespace MeetDay.Infraestructura.Output.Data.Postgresql.Repositories
{
    public class ManagementRepository : IManagementRepository<Management, int>
    {
        private readonly MeetDayContext _db;
        public ManagementRepository(MeetDayContext context)
        {
            _db = context;
        }
        public async Task<Management> AddAsync(Management entity)
        {
            await _db.Managements.AddAsync(entity);
            _db.SaveChanges();
            return entity;
        }

        public void Delete(Management entity)
        {
            _db.Managements.Remove(entity);
            _db.SaveChanges();
        }

        public int Edit(Management entity)
        {
            _db.Managements.Update(entity);
            return _db.SaveChanges();
        }

        public List<Management> FindAll()
        {
            return _db.Managements.ToList();
        }

        public async Task<Management> FindById(int id)
        {
            return await _db.Managements.FindAsync(id);
        }
    }
}