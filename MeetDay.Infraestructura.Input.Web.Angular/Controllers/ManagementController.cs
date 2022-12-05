using AutoMapper;
using MeetDay.Aplicacion.Core.Interfaces;
using MeetDay.Dominio.Core.Dtos;
using MeetDay.Dominio.Core.Dtos.Management;
using MeetDay.Dominio.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace MeetDay.Infraestructura.Input.Web.Angular.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagementController : ControllerBase
    {
        private readonly ILogger<ManagementController> _logger;
        private readonly IManagementService _managementService;
        private readonly IMapper _mapper;
        public ManagementController(IMapper mapper, ILogger<ManagementController> logger, IManagementService managementService)
        {
            _logger = logger;
            _managementService = managementService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<ResponseDto> GetAll()
        {
            try
            {
                var managements= _mapper.Map<List<ManagementDto>>(_managementService.GetAll());
                return new ResponseDto
                {
                    Success = true,
                    Result = managements,
                    Message = "",
                    Errors = {}
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ResponseDto> Get(int id)
        {
            try
            {
                var management = _mapper.Map<ManagementDto>(_managementService.GetById(id));
                return new ResponseDto
                {
                    Success = true,
                    Result = management,
                    Message = "",
                    Errors = {}
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}