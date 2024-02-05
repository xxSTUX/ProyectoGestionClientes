namespace HManagementLead.Entities
{
    public class ProyectoDetalle
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public int IdCliente { get; set; }

        public string NombreCliente { get; set; } = null!;

        public DateTime FechaCreacion{ get; set; }

        public IList<TablaIntermedia> Seguimientos { get; set; } = new List<TablaIntermedia>();

    }
}
