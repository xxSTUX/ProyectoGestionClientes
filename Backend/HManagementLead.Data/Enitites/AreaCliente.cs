using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{
    [PrimaryKey(nameof(AreaId), nameof(ClienteId))]
    public partial class AreaCliente
    {
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;
        public int AreaId { get; set; }
        public Area Area { get; set; } = null!;
        public AreaCliente() { }
        public AreaCliente(int IdArea, int IdCliente)
        {
            this.AreaId = IdArea;
            this.ClienteId= IdCliente;
        }
    }
}
