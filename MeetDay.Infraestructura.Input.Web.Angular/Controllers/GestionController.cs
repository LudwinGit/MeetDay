using MeetDay.Aplicacion.Core.Interfaces;
using MeetDay.Dominio.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace MeetDay.Infraestructura.Input.Web.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestionController : ControllerBase
    {
        // private readonly IGestionService<Gestion,Guid> _gestionService;
        public GestionController()
        {
            // _gestionService = gestionService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("helthcheck");
        }
    }
}