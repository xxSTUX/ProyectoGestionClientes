using System.Text.Json.Serialization;

namespace HManagementLead.Entities
{
    public class ProyectoDetalle
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;
        [JsonIgnore]
        public int IdCliente { get; set; }
        [JsonIgnore]
        public string NombreCliente { get; set; } = null!;

        public DateTime FechaCreacion{ get; set; }
        [JsonIgnore]
        public IList<TablaIntermedia> Seguimientos { get; set; } = new List<TablaIntermedia>();

    }
}
