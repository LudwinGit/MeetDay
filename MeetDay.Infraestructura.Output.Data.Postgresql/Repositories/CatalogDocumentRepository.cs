using MeetDay.Dominio.Core.Entity;
using MeetDay.Dominio.Core.Interfaces.Repositories;
using MeetDay.Infraestructura.Output.Data.Postgresql.Contexts;

namespace MeetDay.Infraestructura.Output.Data.Postgresql.Repositories
{
    public class CatalogDocumentRepository : ICatalogoDocumentRepository<CatalogDocument, int>
    {
        private readonly MeetDayContext _db;
        public CatalogDocumentRepository(MeetDayContext context)
        {
            _db = context;
        }
        public async Task<CatalogDocument> AddAsync(CatalogDocument entity)
        {
            await _db.CatalogDocuments.AddAsync(entity);
            _db.SaveChanges();
            return entity;
        }

        public void Delete(CatalogDocument entity)
        {
            throw new NotImplementedException();
        }

        public int Edit(CatalogDocument entity)
        {
            throw new NotImplementedException();
        }

        public List<CatalogDocument> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<CatalogDocument> FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}