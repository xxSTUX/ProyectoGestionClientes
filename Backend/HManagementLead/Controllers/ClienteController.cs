using HManagementLead.Bll;
using HManagementLead.Bll.Interfaces;
using HManagementLead.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HManagementLead.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(IClienteService clienteService,
            ILogger<ClienteController> logger)
        {
            _clienteService = clienteService ?? throw new ArgumentNullException(nameof(clienteService)); //Si es nulo tira el ArgumentNullException
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var resultado = await _clienteService.GetAllClientesAsync();


                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en ClientController Get clientes");
                throw;
            }
        }
        //Arbol nombres e ids de todos los clientes
        [HttpGet("Arbol")]
        public async Task<IActionResult> GetBasic2()
        {
            try
            {
                var resultado = await _clienteService.GetAllClientesCompletoAsync();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en ClientController Get Arbol");
                throw;
            }
        }
        [HttpGet("Codigo")]
        public async Task<IActionResult> GetCodigo()
        {
            try
            {
                var resultado = await _clienteService.GetAllClientesAsyncToCodigo();

                return Ok(resultado);
    }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en ClientController Get clientes to codigo");
                throw;
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            try
            {
                var resultado = await _clienteService.GetClienteByIdAsync(id);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en ClientController Get cliente");
                throw;
            }
        }


        // GET api/<ClienteController>
        [HttpGet("nombre/{nombre}")]
        public async Task<IActionResult> GetName(string nombre)
        {
            try
            {
                var clienteExists = await _clienteService.ClienteExistsAsync(nombre); // Método para verificar si el cliente existe en la base de datos

                return Ok(clienteExists);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en ClientController Get cliente");
                throw;
            }
        }



        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteDetalle value)
        {
            try
            {
                var resultado = await _clienteService.InsertClienteAsync(value);

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
        public async Task<IActionResult> Put(int id, [FromBody] ClienteDetalle value)
        {
            try
            {
                value.Id = id;
                var resultado = await _clienteService.UpdateClienteAsync(value);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en ClientController Put");
                throw;
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpPut("UpdateEliminado/{id}")]
        public async Task<IActionResult> Put(int id)
        {
            try
            {
                var resultado = await _clienteService.DeleteClienteAsync(id);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en ClientController Delete");
                throw;
            }

        }

        // POST api/<ClienteController>/
        [HttpPost("InsertProyecto/{id}")]
        public async Task<IActionResult> postProyecto(int id, [FromBody] ProyectoDetalle value)
        {
            try
            {
                value.IdCliente = id;
                var resultado = await _clienteService.InsertProyectoInClienteAsync(id, value);

                return Ok(resultado); ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en ClientController Post");
                throw;
            }
        }
        // POST api/<ClienteController>
        [HttpPost("InsertSeguimiento/{id}")]
        public async Task<IActionResult> postSeguimiento(int id, [FromBody] SeguimientoDetalle value)
        {
            try
            {
                var resultado = await _clienteService.InsertSeguimientoInClienteAsync(id, value);

                return Ok(resultado); ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en ClientController Post");
                throw;
            }
        }

        [HttpPost("InsertLicitacion/{id}")]
        public async Task<IActionResult> postLicitacion(int id, [FromBody] LicitacionDetalle value)
        {
            try
            {
                var resultado = await _clienteService.InsertLicitacionInClienteAsync(id, value);

                return Ok(resultado); ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en ClientController Post");
                throw;
            }
        }
        [HttpGet("clientenombre/{nombre}")]
        public async Task<IActionResult> GetClienteNombre(string nombre)
        {
            try
            {
                var resultado = await _clienteService.GetClienteByNombre(nombre);


                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en ClientController Get cliente");
                throw;
            }
        }
    }
}
