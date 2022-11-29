using MeetDay.Dominio.Core.Dtos.User;
using MeetDay.Dominio.Core.Entity;

namespace MeetDay.Aplicacion.Core.Interfaces
{
    public interface IUserService
    {
         bool Login(LoginDto loginDto);
    }
}