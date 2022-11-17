using Microsoft.AspNetCore.Mvc;

namespace MeetDay.Infraestructura.Input.Web.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestionController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}