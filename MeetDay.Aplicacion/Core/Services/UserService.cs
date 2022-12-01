using System.Security.Authentication;
using MeetDay.Aplicacion.Core.Interfaces;
using MeetDay.Aplicacion.Utils;
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
            if(PasswordHasher.VerifyPassword(loginDto.password,user.Password))
                throw new InvalidCredentialException("Login - Password Invalid.");
            return true;
        }

        public User Register(RegisterDto registerDto)
        {
            var user = _userRepository.FindByUsername(registerDto.Username);
            if(user!=null)
                throw new ExistException("El usuario ya existe");

            user = _userRepository.FindByEmail(registerDto.Email);
            
            if(user!=null)
                throw new ExistException("El correo ya existe.");


            var newUser =_userRepository.Add(new User{
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Username = registerDto.Username,
                Password = PasswordHasher.HashPassword(registerDto.Password),
                Email = registerDto.Email,
                Role = "USR",
                Token = ""
            });
            return newUser;
        }
    }
}