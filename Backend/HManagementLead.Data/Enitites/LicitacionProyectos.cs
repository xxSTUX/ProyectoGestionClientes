using Microsoft.EntityFrameworkCore;

namespace HManagementLead.Data.Enitites
{

    [PrimaryKey(nameof(Proyecto_id), nameof(Licitacion_id))]
    public partial class LicitacionProyectos
    {
        public int Proyecto_id { get; set; }
        public int Licitacion_id { get; set; }
        public virtual Proyecto IdProyectoNavigation { get; set; } = null!;
        public virtual Licitaciones IdLicitacionNavigation { get; set; } = null!;
        public LicitacionProyectos() { }
        public LicitacionProyectos(int IdProyecto, int IdLicitacion) 
        {
            this.Proyecto_id = IdProyecto;
            this.Licitacion_id = IdLicitacion;
        }

    }
}
