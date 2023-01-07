using MeetDay.Aplicacion.Core.Interfaces;
using MeetDay.Dominio.Core.Dtos.Document;
using MeetDay.Dominio.Core.Entity;

namespace MeetDay.Aplicacion.Core.Services
{
    public class CatalogDocumentService : ICatalogDocumentService
    {
        public Task<CatalogDocument> Create(CatalogDocumentDto documentDto)
        {
            throw new NotImplementedException();
        }

        public List<CatalogDocument> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CatalogDocument> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(CatalogDocumentDto documentDto)
        {
            throw new NotImplementedException();
        }
    }
}