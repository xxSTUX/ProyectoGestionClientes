using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HManagementLead.Data.Enitites
{

    [PrimaryKey(nameof(AreaId), nameof(SeguimientoId))]
    [Index(nameof(AreaId), nameof(SeguimientoId))]
    public partial class SeguimientoArea
    {
        [Key]
        [Column(Order = 0)]
        public int AreaId { get; set; }
        public Area Area { get; set; }
        [Key]
        [Column(Order = 1)]
        public int SeguimientoId { get; set; }
        public Seguimiento Seguimiento { get; set; } = null!;
        public SeguimientoArea() { }
        public SeguimientoArea(int IdArea, int IdSeguimiento) 
        {
            this.AreaId = IdArea;
            this.SeguimientoId = IdSeguimiento;
        }

    }
}
