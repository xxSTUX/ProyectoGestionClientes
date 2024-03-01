using System.Text.Json.Serialization;

namespace HManagementLead.Entities
{
    public class ProyectoDetalle
    {
        //[JsonIgnore]
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        [JsonIgnore]
        public int IdCliente { get; set; }
        public string Estado { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        [JsonIgnore]
        public IList<TablaIntermedia> SeguimientoProyecto { get; set; } = new List<TablaIntermedia>();
        public virtual IList<SeguimientoDetalle> Seguimientos { get; set; } = new List<SeguimientoDetalle>();
        public virtual IList<LicitacionDetalle> Licitaciones { get; set; } = new List<LicitacionDetalle>();
        public virtual IList<FacturacionDetalle> Facturacion { get; set; } = new List<FacturacionDetalle>();
        public virtual IList<PuestoDetalle> Puestos { get; set; } = new List<PuestoDetalle>();

    }
}
