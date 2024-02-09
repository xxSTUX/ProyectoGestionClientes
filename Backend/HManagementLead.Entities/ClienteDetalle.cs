using System.Text.Json.Serialization;

namespace HManagementLead.Entities
{
    public class ClienteDetalle
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonPropertyName("Nombre Cliente")]
        public string Nombre { get; set; } = null!;
        [JsonPropertyName("Proyectos")]
        public IList<ProyectoDetalle> Proyectos { get; set; } = new List<ProyectoDetalle>();
        [JsonIgnore]
        public IList<TablaIntermedia> SeguimientoCliente { get; set; } = new List<TablaIntermedia>();
        [JsonPropertyName("Seguimientos de cliente")]
        public virtual IList<SeguimientoDetalle> Seguimientos { get; set; } = new List<SeguimientoDetalle>();
        [JsonPropertyName("Licitaciones de cliente")]
        public virtual IList<LicitacionDetalle> licitaciones { get; set; } = new List<LicitacionDetalle>();
    }
}
