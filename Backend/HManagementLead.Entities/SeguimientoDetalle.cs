using System.Text.Json.Serialization;

namespace HManagementLead.Entities
{
    public class SeguimientoDetalle
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Tipo { get; set; } = null!;
    }
}
