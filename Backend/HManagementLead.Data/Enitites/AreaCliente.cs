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
    [PrimaryKey(nameof(ClienteId), nameof(AreaId))]
    [Index(nameof(ClienteId), nameof(AreaId))]
    public partial class AreaCliente
    {
        [Key]
        [Column(Order = 0)]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;
        [Key]
        [Column(Order = 1)]
        public int AreaId { get; set; }
        public Area Area { get; set; } = null!;
        public AreaCliente(int IdArea, int IdCliente)
        {
            this.AreaId = IdArea;
            this.ClienteId= IdCliente;
        }
    }
}
