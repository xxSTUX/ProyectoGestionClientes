using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{

    [PrimaryKey(nameof(Cliente_id), nameof(Seguimiento_id))]
    public partial class SeguimientoClientes
    {
        public int Cliente_id { get; set; }
        public int Seguimiento_id { get; set; }
        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Seguimientos IdSeguimientoNavigation { get; set; } = null!;
        public SeguimientoClientes() { }
        public SeguimientoClientes(int IdCliente, int IdSeguimiento) 
        {
            this.Cliente_id = IdCliente;
            this.Seguimiento_id = IdSeguimiento;
        }

    }
}
