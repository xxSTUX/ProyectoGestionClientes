using HManagementLead.Bll.Interfaces;
using HManagementLead.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HManagementLead.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguimientoController : ControllerBase
    {
        private readonly ISeguimientoService _seguimientoService;
        private readonly ILogger<SeguimientoController> _logger;

        public SeguimientoController(ISeguimientoService seguimientoService,
            ILogger<SeguimientoController> logger)
        {
            _seguimientoService = seguimientoService ?? throw new ArgumentNullException(nameof(seguimientoService));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var resultado = await _seguimientoService.GetAllSeguimientoAsync();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en SeguimientoController Get clientes");
                throw;
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var resultado = await _seguimientoService.GetSeguimientoByIdAsync(id);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en SeguimientoController Get cliente");
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SeguimientoDetalle value)
        {
            try
            {
                var resultado = await _seguimientoService.InsertSeguimientoAsync(value);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en SeguimientoController Post Seguimiento");
                throw;
            }
        }
        [HttpPut("{id}")] 
        public async Task <IActionResult> Put(int id, [FromBody] SeguimientoDetalle value)
        {
            try
            {
                var resultado = await _seguimientoService.UpdateSeguimientoAsync(id,value);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en SeguimientoController Put Seguimiento por Id");
                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _seguimientoService.DeleteSeguimientoByIdAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en SeguimientoController Delete Seguimiento por Id");
                throw;
            }
        }
    }
}
