using MeetDay.Dominio.Core.Dtos.Catolog;

namespace MeetDay.Aplicacion.Core.Interfaces
{
    public interface ICatalogService
    {
         Task<List<OptionDto>> getAllCatalogDocument();
    }
}