using MeetDay.Aplicacion.Core.Interfaces;
using MeetDay.Dominio.Core.Dtos.Catolog;
using MeetDay.Dominio.Core.Interfaces.Repositories;

namespace MeetDay.Aplicacion.Core.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _repository;
        public CatalogService(ICatalogRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<OptionDto>> getAllCatalogDocument()
        {
            return await _repository.getAllCatalogDocument();
        }
    }
}