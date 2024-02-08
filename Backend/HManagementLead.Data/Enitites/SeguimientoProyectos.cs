using Microsoft.EntityFrameworkCore;

namespace HManagementLead.Data.Enitites
{

    [PrimaryKey(nameof(Proyecto_id), nameof(Seguimiento_id))]
    public partial class SeguimientoProyectos
    {
        public int Proyecto_id { get; set; }
        public int Seguimiento_id { get; set; }
        public virtual Proyecto IdProyectoNavigation { get; set; } = null!;
        public virtual Seguimientos IdSeguimientoNavigation { get; set; } = null!;
        public SeguimientoProyectos() { }
        public SeguimientoProyectos(int IdProyecto, int IdSeguimiento) 
        {
            this.Proyecto_id = IdProyecto;
            this.Seguimiento_id = IdSeguimiento;
        }

    }
}
