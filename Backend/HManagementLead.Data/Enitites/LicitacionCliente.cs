using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{

    [PrimaryKey(nameof(ClienteId), nameof(LicitacionId))]
    [Index(nameof(ClienteId), nameof(LicitacionId))]
    public partial class LicitacionCliente
    {
        [Key]
        [Column(Order = 0)] // Indica el orden en la clave principal compuesta
        public int ClienteId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int LicitacionId { get; set; }
        public Cliente Cliente { get; set; } = null!;
        public Licitacion Licitacion { get; set; } = null!;
        public LicitacionCliente() { }
        public LicitacionCliente(int IdCliente, int IdLicitacion) 
        {
            this.ClienteId = IdCliente;
            this.LicitacionId = IdLicitacion;
        }

    }
}
