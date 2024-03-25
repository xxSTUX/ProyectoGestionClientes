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
    [PrimaryKey(nameof(ProyectoId), nameof(PuestoId))]
    [Index(nameof(ProyectoId), nameof(PuestoId))]
    public partial class PuestoProyecto
    {
        [Key]
        [Column(Order = 0)]
        public int ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; } = null!;
        [Key]
        [Column(Order = 1)]
        public int PuestoId { get; set; }
        public Puesto Puesto { get; set; } = null!;
    }
}
