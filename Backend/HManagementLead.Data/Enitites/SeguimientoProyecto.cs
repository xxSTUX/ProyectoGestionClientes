using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HManagementLead.Data.Enitites
{

    [PrimaryKey(nameof(ProyectoId), nameof(SeguimientoId))]
    [Index(nameof(ProyectoId), nameof(SeguimientoId))]
    public partial class SeguimientoProyecto
    {
        [Key]
        [Column(Order = 0)]
        public int ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }
        [Key]
        [Column(Order = 1)]
        public int SeguimientoId { get; set; }
        public Seguimiento Seguimiento { get; set; } = null!;
        public SeguimientoProyecto() { }
        public SeguimientoProyecto(int IdProyecto, int IdSeguimiento) 
        {
            this.ProyectoId = IdProyecto;
            this.SeguimientoId = IdSeguimiento;
        }

    }
}
