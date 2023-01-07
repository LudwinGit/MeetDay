using MeetDay.Dominio.Core.Dtos.Document;
using MeetDay.Dominio.Core.Entity;

namespace MeetDay.Aplicacion.Core.Interfaces
{
    public interface ICatalogDocumentService
    {
        Task<CatalogDocument> Create(CatalogDocumentDto documentDto);
        Task<int> Update(CatalogDocumentDto documentDto);
        List<CatalogDocument> GetAll();
        Task<CatalogDocument> GetById(int id);
    }
}