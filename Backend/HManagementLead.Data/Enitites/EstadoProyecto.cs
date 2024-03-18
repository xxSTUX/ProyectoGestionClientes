using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{
    public class EstadoProyecto
    {
        public int Id { get; set; }

        public string Estado { get; set; } = null;
        public EstadoProyecto() { }
    }
}
