namespace HManagementLead.Entities
{
    public class ClienteDetalle
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public IList<Codigo> Proyectos { get; set; } = new List<Codigo>();

        public IList<TablaIntermedia> Seguimientos { get; set; } = new List<TablaIntermedia>();

        public virtual IList<SeguimientoDetalle> SeguimientoClientes { get; set; } = new List<SeguimientoDetalle>();
    }
}
