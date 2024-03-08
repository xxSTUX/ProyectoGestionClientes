using System.Text.Json.Serialization;

namespace HManagementLead.Entities
{
    public class Codigo
    {
        public int CodigoId { get; set; }
        public string Descripcion { get; set; } = null!;
    }
}
