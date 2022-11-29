using MeetDay.Aplicacion.Core.Interfaces;
using MeetDay.Dominio.Core.Dtos.User;
using MeetDay.Dominio.Core.Entity;
using MeetDay.Dominio.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace MeetDay.Infraestructura.Input.Web.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        public UserController(ILogger<UserController> logger,IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult get(){
            return Ok("yes");
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] LoginDto loginDto)
        {
            try
            {
                if(_userService.Login(loginDto))
                    return Ok();

                return StatusCode(StatusCodes.Status401Unauthorized);
            }
            catch (NotFoundException ex)
            {
                _logger.LogInformation(ex.Message,ex);
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}