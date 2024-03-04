using HManagementLead.Bll.Interfaces;
using HManagementLead.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HManagementLead.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuestoController : ControllerBase
    {
        private readonly IPuestoService _puestoService;
        private readonly ILogger<PuestoController> _logger;

        public PuestoController(IPuestoService puestoService,
            ILogger<PuestoController> logger)
        {
            _puestoService = puestoService ?? throw new ArgumentNullException(nameof(puestoService));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        // GET api/<FacturacionController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var resultado = await _puestoService.GetAllPuestoAsync();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en PuestoController Get puestos");
                throw;
            }
        }

        // GET api/<FacturacionController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var resultado = await _puestoService.GetPuestoByIdAsync(id);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en PuestoController Get puesto");
                throw;
            }
        }
    }
}