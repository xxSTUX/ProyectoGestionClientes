using HManagementLead.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HManagementLead.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class SaludoController : Controller
    {
        private readonly ApplicationDbContext _context;

        [HttpGet]
        public string Get()
        {
           
            return "Hola";           
        }
    }
}
