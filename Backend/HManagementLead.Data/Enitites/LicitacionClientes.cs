using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{

    [PrimaryKey(nameof(Cliente_id), nameof(Licitacion_id))]
    public partial class LicitacionClientes
    {
        public int Cliente_id { get; set; }
        public int Licitacion_id { get; set; }
        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Licitaciones IdLicitacionNavigation { get; set; } = null!;
        public LicitacionClientes() { }
        public LicitacionClientes(int IdCliente, int IdLicitacion) 
        {
            this.Cliente_id = IdCliente;
            this.Licitacion_id = IdLicitacion;
        }

    }
}
