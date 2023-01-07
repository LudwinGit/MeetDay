using MeetDay.Dominio.Core.Entity;
using MeetDay.Dominio.Core.Interfaces.Repositories;
using MeetDay.Infraestructura.Output.Data.Postgresql.Contexts;

namespace MeetDay.Infraestructura.Output.Data.Postgresql.Repositories
{
    public class ManagementDocumentRepository : IManagementDocumentRepository<DocumentManagement, int>
    {
        private readonly MeetDayContext _db;
        public ManagementDocumentRepository(MeetDayContext context)
        {
            _db = context;
        }
        public async Task<DocumentManagement> AddAsync(DocumentManagement entity)
        {
            await _db.DocumentManagements.AddAsync(entity);
            _db.SaveChanges();
            return entity;
        }

        public void Delete(DocumentManagement entity)
        {
            throw new NotImplementedException();
        }

        public int Edit(DocumentManagement entity)
        {
            throw new NotImplementedException();
        }

        public List<DocumentManagement> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<DocumentManagement> FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}