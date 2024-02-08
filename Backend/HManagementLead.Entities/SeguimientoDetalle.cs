using System.Text.Json.Serialization;

namespace HManagementLead.Entities
{
    public class SeguimientoDetalle
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonPropertyName("Nombre seguimiento")]
        public string Nombre { get; set; }
    }
}
