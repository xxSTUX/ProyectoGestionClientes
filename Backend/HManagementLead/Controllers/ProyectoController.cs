using HManagementLead.Bll.Interfaces;
using HManagementLead.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HManagementLead.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        public ClienteController ClienteController { get; set; }
        private readonly IProyectoService _proyectoService;
        private readonly ILogger<ProyectoController> _logger;

        public ProyectoController(IProyectoService proyectoService,
            ILogger<ProyectoController> logger)
        {
            _proyectoService = proyectoService ?? throw new ArgumentNullException(nameof(proyectoService));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var resultado = await _proyectoService.GetAllProyectosAsync();

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
                var resultado = await _proyectoService.GetProyectoByIdAsync(id);
                

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en ClientController Get cliente");
                throw;
            }
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProyectoDetalle value)
        {
            try
            {
                var resultado = await _proyectoService.InsertProyectoAsync(value);

                return Ok(resultado); ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en ClientController Post");
                throw;
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProyectoDetalle value)
        {
            try
            {
                var resultado = await _proyectoService.UpdateProyectoAsync(value);


                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en ClientController Put");
                throw;
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _proyectoService.DeleteProyectoAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en ClientController Delete");
                throw;
            }

        }
    }
}
