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
            // _db.Managements.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async void Delete(Management entity)
        {
            // _db.Managements.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<int> Edit(Management entity)
        {
            // _db.Managements.Update(entity);
            return await _db.SaveChangesAsync();
        }

        public List<Management> FindAll()
        {
            return null;
            // return _db.Managements.ToList();
        }

        public async Task<Management> FindById(int id)
        {
            return null;
            // return await _db.Managements.FindAsync(id);
        }
    }
}