using System.Text.Json.Serialization;

namespace HManagementLead.Entities
{
    public class LicitacionDetalle
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonPropertyName("Nombrelicitacion")]
        public string Nombre { get; set; } = null!;
    }
}
