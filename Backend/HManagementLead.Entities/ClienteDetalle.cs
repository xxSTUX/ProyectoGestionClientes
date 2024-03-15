using System.Text.Json.Serialization;

namespace HManagementLead.Entities
{
    public class ClienteDetalle
    {
        //[JsonIgnore]
        //public int Id { get; set; }
        //public string Nombre { get; set; } = null!;
        //public IList<ProyectoDetalle> Proyectos { get; set; } = new List<ProyectoDetalle>();
        [JsonIgnore]
        public IList<TablaIntermedia> SeguimientoCliente { get; set; } = new List<TablaIntermedia>();
        //public virtual IList<SeguimientoDetalle> Seguimientos { get; set; } = new List<SeguimientoDetalle>();
        //public virtual IList<LicitacionDetalle> licitaciones { get; set; } = new List<LicitacionDetalle>();
        //[JsonIgnore]
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Eliminado { get; set; } = false;

        public IList<ProyectoDetalle> Proyectos { get; set; } = new List<ProyectoDetalle>();
        public virtual IList<SeguimientoDetalle> Seguimientos { get; set; } = new List<SeguimientoDetalle>();
        public virtual IList<LicitacionDetalle> Licitaciones { get; set; } = new List<LicitacionDetalle>();
        public virtual IList<ContactoDetalle> Contactos { get; set; } = new List<ContactoDetalle>();
        public virtual IList<FacturacionDetalle> Facturacion { get; set; } = new List<FacturacionDetalle>();
        public virtual IList<PuestoDetalle> Puestos { get; set; } = new List<PuestoDetalle>();










    }
}
