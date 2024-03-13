using System.Text.Json.Serialization;

namespace HManagementLead.Entities
{
    public class SeguimientoDetalle
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public DateTime Fecha { get; set; } = DateTime.Today;
        public string Observaciones { get; set; } = null!;
        public bool Eliminado { get; set; } = false;

    }
}
