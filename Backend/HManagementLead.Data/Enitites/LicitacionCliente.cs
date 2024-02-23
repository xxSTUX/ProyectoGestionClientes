using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{

    [PrimaryKey(nameof(ClienteId), nameof(LicitacionId))]
    public partial class LicitacionCliente
    {
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;
        public int LicitacionId { get; set; }
        public Licitacion Licitacion { get; set; } = null!;
        public LicitacionCliente() { }
        public LicitacionCliente(int IdCliente, int IdLicitacion) 
        {
            this.ClienteId = IdCliente;
            this.LicitacionId = IdLicitacion;
        }

    }
}
