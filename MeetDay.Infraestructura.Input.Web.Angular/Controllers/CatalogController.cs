using AutoMapper;
using MeetDay.Aplicacion.Core.Interfaces;
using MeetDay.Dominio.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MeetDay.Infraestructura.Input.Web.Angular.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger<CatalogController> _logger;
        private readonly ICatalogService _catalogService;
        private readonly IMapper _mapper;

        public CatalogController(IMapper mapper, ILogger<CatalogController> logger, ICatalogService catalogService)
        {
            _logger = logger;
            _catalogService = catalogService;
            _mapper = mapper;
        }

        [HttpGet("documents")]
        public async Task<ResponseDto> GetAllCatalogDocuments()
        {
            try
            {
                var catalogs = await _catalogService.getAllCatalogDocument();
                return new ResponseDto
                {
                    Success = true,
                    Result = catalogs,
                    Message = "",
                    Errors = { }
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new ResponseDto
                {
                    Success = false,
                    Result = null,
                    Message = "",
                    Errors = { ex.ToString() }
                };
            }
        }

    }
}