using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HManagementLead.Data.Enitites
{

    [PrimaryKey(nameof(ProyectoId), nameof(LicitacionId))]
    [Index(nameof(ProyectoId), nameof(LicitacionId))]
    public partial class LicitacionProyecto
    {
        [Key]
        [Column(Order = 0)]
        public int ProyectoId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int LicitacionId { get; set; }
        public Proyecto Proyecto { get; set; } = null!;
        public Licitacion Licitacion { get; set; } = null!;

        public LicitacionProyecto() { }
        public LicitacionProyecto(int IdProyecto, int IdLicitacion) 
        {
            this.ProyectoId = IdProyecto;
            this.LicitacionId = IdLicitacion;
        }

    }
}
