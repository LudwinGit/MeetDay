using MeetDay.Dominio.Core.Dtos.Management;
using MeetDay.Dominio.Core.Entity;

namespace MeetDay.Aplicacion.Core.Interfaces
{
    public interface IManagementService
    {
         Task<Management> Create(ManagementDto managementDto);
         Task<int> Update(ManagementDto managementDto);
         List<Management> GetAll();
         Task<Management> GetById(int id);
    }
}