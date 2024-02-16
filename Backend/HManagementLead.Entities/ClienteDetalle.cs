using System.Text.Json.Serialization;

namespace HManagementLead.Entities
{
    public class ClienteDetalle
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public IList<ProyectoDetalle> Proyectos { get; set; } = new List<ProyectoDetalle>();
        [JsonIgnore]
        public IList<TablaIntermedia> SeguimientoCliente { get; set; } = new List<TablaIntermedia>();
        public virtual IList<SeguimientoDetalle> Seguimientos { get; set; } = new List<SeguimientoDetalle>();
        public virtual IList<LicitacionDetalle> licitaciones { get; set; } = new List<LicitacionDetalle>();
    }
}
