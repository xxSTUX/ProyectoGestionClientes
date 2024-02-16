using System.Text.Json.Serialization;

namespace HManagementLead.Entities
{
    public class SeguimientoDetalle
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int ProyectoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; } = null!;
    }
}
