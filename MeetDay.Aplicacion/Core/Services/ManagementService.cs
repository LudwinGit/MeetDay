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
        public ManagementService(IManagementRepository<Management, int> repository)
        {
            _repository = repository;
        }
        public async Task<Management> Create(ManagementDto managementDto)
        {
            var management = await _repository.AddAsync(new Management
            {
                Name = managementDto.Name,
                Observation = managementDto.Observation
            });
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
            return await _repository.Edit(management);
        }
    }
}