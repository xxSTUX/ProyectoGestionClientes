using System.Text.Json.Serialization;

namespace HManagementLead.Entities
{
    public class Codigo
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
    }
}
