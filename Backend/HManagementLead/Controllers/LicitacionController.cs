using HManagementLead.Bll;
using HManagementLead.Bll.Interfaces;
using HManagementLead.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HManagementLead.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicitacionController : ControllerBase
    {
        private readonly ILicitacionService _licitacionService;
        private readonly ILogger<LicitacionController> _logger;

        public LicitacionController(ILicitacionService licitacionService,
            ILogger<LicitacionController> logger)
        {
            _licitacionService = licitacionService ?? throw new ArgumentNullException(nameof(licitacionService));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var resultado = await _licitacionService.GetAllLicitacionAsync();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en ClientController Get clientes");
                throw;
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var resultado = await _licitacionService.GetLicitacionByIdAsync(id);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en ClientController Get cliente");
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LicitacionDetalle value)
        {
            try
            {
                var resultado = await _licitacionService.InsertLicitacionAsync(value);

                return Ok(resultado); ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en ClientController Post");
                throw;
            }
        }
    }
}
