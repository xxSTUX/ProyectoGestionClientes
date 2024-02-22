using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{

    [PrimaryKey(nameof(ClienteId), nameof(SeguimientoId))]
    public partial class SeguimientoCliente
    {
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        public int SeguimientoId { get; set; }
        public Seguimiento Seguimiento { get; set; } = null!;

        public SeguimientoCliente() { }
        public SeguimientoCliente(int IdCliente, int IdSeguimiento) 
        {
            this.ClienteId = IdCliente;
            this.SeguimientoId = IdSeguimiento;
        }
    }
}
