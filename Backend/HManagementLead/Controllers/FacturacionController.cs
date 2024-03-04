using HManagementLead.Bll.Interfaces;
using HManagementLead.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HManagementLead.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturacionController : ControllerBase
    {
        private readonly IFacturacionService _facturacionService;
        private readonly ILogger<FacturacionController> _logger;

        public FacturacionController(IFacturacionService facturacionService,
            ILogger<FacturacionController> logger)
        {
            _facturacionService = facturacionService ?? throw new ArgumentNullException(nameof(facturacionService));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        // GET api/<FacturacionController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var resultado = await _facturacionService.GetAllFacturacionAsync();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en FacturacionController Get facturaciones");
                throw;
            }
        }

        // GET api/<FacturacionController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var resultado = await _facturacionService.GetFacturacionByIdAsync(id);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en FacturacionController Get facturacion");
                throw;
            }
        }
    }
}