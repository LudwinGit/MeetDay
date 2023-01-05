using System.Net;
using System.Security.Claims;
using System.Security.Authentication;
using MeetDay.Aplicacion.Core.Interfaces;
using MeetDay.Dominio.Core.Dtos.User;
using MeetDay.Dominio.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MeetDay.Infraestructura.Input.Web.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] LoginDto loginDto)
        {
            try
            {
                var user = _userService.Login(loginDto);
                return Ok(user);
            }
            catch (NotFoundException ex)
            {
                _logger.LogInformation(ex.Message, ex);
                return NotFound(new { Message = "¡Usuario no existe!" });
            }
            catch (InvalidCredentialException ex)
            {
                _logger.LogInformation(ex.Message, ex);
                return Unauthorized(new { Message = "¡Credenciales incorrectas!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userService.Register(registerDto);
                    if (user != null)
                        return Ok(user);
                    return BadRequest(new { Message = "No se pudo crear el usuario" });
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (ExistException ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest("Error del servidor");
            }
        }

        [HttpGet("test")]
        [Authorize]
        public IActionResult test()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            return Ok();
        }
    }
}