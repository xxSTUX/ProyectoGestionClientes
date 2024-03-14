using HManagementLead.Bll.Interfaces;
using HManagementLead.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HManagementLead.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        private readonly IContactoService _contactoService;
        private readonly ILogger<ContactoController> _logger;

        public ContactoController(IContactoService contactoService,
            ILogger<ContactoController> logger)
        {
            _contactoService = contactoService ?? throw new ArgumentNullException(nameof(contactoService));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var resultado = await _contactoService.GetAllContactoAsync();

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
                var resultado = await _contactoService.GetContactoByIdAsync(id);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en ClientController Get cliente");
                throw;
            }
        }

        [HttpPut("UpdateEliminado/{id}")]
        public async Task<IActionResult> UpdateEliminadoAsync(int id)
        {
            try
            {

                var resultado = await _contactoService.UpdateEliminadoAsync(id);


                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en ClientController Put");
                throw;
            }
        }
    }
}
