using Microsoft.EntityFrameworkCore;

namespace HManagementLead.Data.Enitites
{

    [PrimaryKey(nameof(ProyectoId), nameof(SeguimientoId))]
    public partial class SeguimientoProyecto
    {
        public int ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }
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
