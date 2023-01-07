using MeetDay.Dominio.Core.Dtos.Catolog;

namespace MeetDay.Dominio.Core.Interfaces.Repositories
{
    public interface ICatalogRepository
    {
        Task<List<OptionDto>> getAllCatalogDocument();        
    }
}