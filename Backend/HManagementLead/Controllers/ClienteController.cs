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

        [HttpGet("Basic")]
        public async Task<IActionResult> GetBasic()
        {
            try
            {
                var resultado = await _clienteService.GetAllClientesBasicAsync();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en ClientController Get clientes to codigo");
                throw;
            }
        }
        [HttpGet("Basic/Completo/{id}")]
        public async Task<IActionResult> GetBasic(int id)
        {
            try
            {
                var resultado = await _clienteService.GetClienteBasicCompletoByIdAsync(id);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error en ClientController Get clientes to codigo");
                throw;
            }
        }

        // GET api/<ClienteController>/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //    {
        //        try
        //        {
        //            var resultado = await _clienteService.GetClienteByIdAsync(id);

        //            return Ok(resultado);
        //}
        //        catch (Exception ex)
        //        {
        //            _logger.LogError(ex, "Ocurrió un error en ClientController Get cliente");
        //            throw;
        //        }
        //    }



        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _clienteService.DeleteClienteAsync(id);

                return NoContent();
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
    }
}
