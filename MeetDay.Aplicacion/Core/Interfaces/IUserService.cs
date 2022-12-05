using MeetDay.Dominio.Core.Dtos;
using MeetDay.Dominio.Core.Dtos.User;
using MeetDay.Dominio.Core.Entity;

namespace MeetDay.Aplicacion.Core.Interfaces
{
    public interface IUserService
    {
         ResponseDto Login(LoginDto loginDto);
         Task<User> Register(RegisterDto registerDto);
    }
}