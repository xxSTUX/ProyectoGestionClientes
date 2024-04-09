using System.Text.Json.Serialization;

namespace HManagementLead.Entities
{
    public class AreaDetalle
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [JsonIgnore]
        public int IdCliente { get; set; }
        public string Responsable { get; set; }
        public string Email { get; set; }
        public bool Eliminado { get; set; } = false;
        [JsonIgnore]
        public IList<TablaIntermedia> SeguimientoArea { get; set; } = new List<TablaIntermedia>();
        public virtual IList<SeguimientoDetalle> Seguimientos { get; set; } = new List<SeguimientoDetalle>();
    }
}
