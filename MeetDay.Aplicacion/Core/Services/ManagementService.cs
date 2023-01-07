using MeetDay.Aplicacion.Core.Interfaces;
using MeetDay.Dominio.Core.Dtos.Management;
using MeetDay.Dominio.Core.Entity;
using MeetDay.Dominio.Core.Exceptions;
using MeetDay.Dominio.Core.Interfaces.Repositories;

namespace MeetDay.Aplicacion.Core.Services
{
    public class ManagementService : IManagementService
    {
        private readonly IManagementRepository<Management, int> _repository;
        private readonly IManagementDocumentRepository<DocumentManagement, int> _managementDocumentrepository;
        public ManagementService(IManagementRepository<Management, int> repository, IManagementDocumentRepository<DocumentManagement, int> managementDocumentrepository)
        {
            _repository = repository;
            _managementDocumentrepository = managementDocumentrepository;
        }
        public async Task<Management> Create(ManagementDto managementDto)
        {
            var management = await _repository.AddAsync(new Management
            {
                Name = managementDto.Name,
                Observation = managementDto.Observation
            });

            List<CatalogDocument> documents = new List<CatalogDocument>();
            foreach (var item in managementDto.Documents)
            {
                await _managementDocumentrepository.AddAsync(new DocumentManagement { ManagementId = management.Id, CatalogDocumentId = (int.Parse(item.key)) });
            }
            return management;
        }

        public List<Management> GetAll()
        {
            return _repository.FindAll();
        }

        public Task<Management> GetById(int id)
        {
            return _repository.FindById(id);
        }

        public async Task<int> Update(ManagementDto managementDto)
        {
            var management = await _repository.FindById(managementDto.Id);
            if (management == null)
                throw new NotFoundException("La gestión no existe.");
            management.Name = managementDto.Name;
            management.DateUpdate = DateTime.Now;
            management.Observation = managementDto.Observation;
            management.State = managementDto.State;
            return _repository.Edit(management);
        }
    }
}