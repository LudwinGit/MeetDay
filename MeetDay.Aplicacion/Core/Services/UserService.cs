using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Security.Authentication;
using MeetDay.Aplicacion.Core.Interfaces;
using MeetDay.Aplicacion.Utils;
using MeetDay.Dominio.Core.Dtos.User;
using MeetDay.Dominio.Core.Entity;
using MeetDay.Dominio.Core.Exceptions;
using MeetDay.Dominio.Core.Interfaces.Repositories;
using MeetDay.Dominio.Core.Class;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using MeetDay.Dominio.Core.Dtos;

namespace MeetDay.Aplicacion.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User, int> _userRepository;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository<User, int> userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public ResponseDto Login(LoginDto loginDto)
        {
            var user = _userRepository.FindByUsername(loginDto.username);
            if (user == null)
                throw new NotFoundException("User Not Found!");
            if (!PasswordHasher.VerifyPassword(loginDto.password, user.Password))
                throw new InvalidCredentialException("Login - Password Invalid.");

            // var jwt = (_configuration.GetSection("Jwt")).Get<Jwt>();
            // var claims = new[]
            // {
            //     new Claim(JwtRegisteredClaimNames.Sub,jwt.Subject),
            //     new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            //     new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
            //     new Claim("id",user.Id.ToString()),
            //     new Claim("username",user.Username),
            //     new Claim("email",user.Email)
            // };
            // var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            // var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // var token = new JwtSecurityToken(jwt.Issuer, jwt.Audience, claims, signingCredentials: singIn);
            var token = generateToken(user);
            return new ResponseDto
            {
                Success = true,
                Message = "Inicio de sesion correcto",
                Result = token
                // Result = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        public async Task<User> Register(RegisterDto registerDto)
        {
            var user = _userRepository.FindByUsername(registerDto.Username);
            if (user != null)
                throw new ExistException("El usuario ya existe");

            user = _userRepository.FindByEmail(registerDto.Email);

            if (user != null)
                throw new ExistException("El correo ya existe.");


            var newUser = await _userRepository.AddAsync(new User
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Username = registerDto.Username,
                Password = PasswordHasher.HashPassword(registerDto.Password),
                Email = registerDto.Email
            });
            return newUser;
        }

        private string generateToken(User user)
        {
            var jwt = (_configuration.GetSection("Jwt")).Get<Jwt>();
            // var secretKey = config.GetValue<string>("SecretKey");
            var key = Encoding.ASCII.GetBytes(jwt.Key);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier,user.Username));
            // claims.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,jwt.Subject));
            //     new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            //     new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
            //     new Claim("id",user.Id.ToString()),
            //     new Claim("username",user.Username),
            //     new Claim("email",user.Email)

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(createdToken);
        }
    }
}