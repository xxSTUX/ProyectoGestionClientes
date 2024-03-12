using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{
    public class ClienteBasicCompleto
    {
        public int ClienteId { get; set; }
        public String Nombre { get; set; } = null!;
        public List<ProyectoBasic> Proyectos { get; set; } = new List<ProyectoBasic>();
        public List<SeguimientoBasic> Seguimientos { get; set; } = new List<SeguimientoBasic>();
        public List<LicitacionBasic> Licitaciones { get; set; } = new List<LicitacionBasic>();
    }
}
