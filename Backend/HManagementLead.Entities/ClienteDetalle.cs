using System.Text.Json.Serialization;

namespace HManagementLead.Entities
{
    public class ClienteDetalle
    {
        public int Id { get; set; }

        
        public string Nombre { get; set; } = null!;
        [JsonIgnore]
        public IList<Codigo> Proyectos { get; set; } = new List<Codigo>();
        [JsonIgnore]
        public IList<TablaIntermedia> Seguimientos { get; set; } = new List<TablaIntermedia>();
        [JsonIgnore]
        public virtual IList<SeguimientoDetalle> SeguimientoClientes { get; set; } = new List<SeguimientoDetalle>();
}
}
