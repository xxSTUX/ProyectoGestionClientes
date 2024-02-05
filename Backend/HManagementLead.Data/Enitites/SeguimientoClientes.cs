using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{

    [PrimaryKey(nameof(IdCliente), nameof(IdSeguimiento))]
    public partial class SeguimientoClientes
    {
        public int IdCliente { get; set; }
        public int IdSeguimiento { get; set; }
        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Seguimiento IdSeguimientoNavigation { get; set; } = null!;
        public SeguimientoClientes() { }
        public SeguimientoClientes(int IdCliente, int IdSeguimiento) 
        {
            this.IdCliente = IdCliente;
            this.IdSeguimiento = IdSeguimiento;
        }

    }
}
