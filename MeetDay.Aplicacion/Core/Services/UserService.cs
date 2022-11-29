using MeetDay.Aplicacion.Core.Interfaces;
using MeetDay.Dominio.Core.Dtos.User;
using MeetDay.Dominio.Core.Entity;
using MeetDay.Dominio.Core.Exceptions;
using MeetDay.Dominio.Core.Interfaces.Repositories;

namespace MeetDay.Aplicacion.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User,int> _userRepository;
        public UserService(IUserRepository<User,int> userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Login(LoginDto loginDto)
        {
            var user = _userRepository.FindByUsername(loginDto.username);
            if(user==null)
                throw new NotFoundException("User Not Found!");
            return true;
        }
    }
}