using System.Text.Json.Serialization;

namespace HManagementLead.Entities
{
    public class SeguimientoDetalle
    {
        public int Id { get; set; }
        public string Usuario { get; set; } = null!;
        public DateTime Fecha { get; set; } = DateTime.Today;
        public string Observaciones { get; set; } = null!;
        public bool Eliminado { get; set; } = false;

    }
}
