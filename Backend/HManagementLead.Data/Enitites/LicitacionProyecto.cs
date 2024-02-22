using Microsoft.EntityFrameworkCore;

namespace HManagementLead.Data.Enitites
{

    [PrimaryKey(nameof(ProyectoId), nameof(LicitacionId))]
    public partial class LicitacionProyecto
    {
        public int ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; } = null!;
        public int LicitacionId { get; set; }
        public Licitacion Licitacion { get; set; } = null!;
        public LicitacionProyecto() { }
        public LicitacionProyecto(int IdProyecto, int IdLicitacion) 
        {
            this.ProyectoId = IdProyecto;
            this.LicitacionId = IdLicitacion;
        }

    }
}
