using System.Text.Json.Serialization;

namespace HManagementLead.Entities
{
    public class LicitacionDetalle
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonPropertyName("Nombre licitacion")]
        public string Nombre { get; set; }
    }
}
