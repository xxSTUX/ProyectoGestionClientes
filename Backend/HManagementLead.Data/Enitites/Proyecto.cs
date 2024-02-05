using HManagementLead.Data.Enitites;
using HManagementLead.Entities;

namespace HManagementLead.Data;

public partial class Proyecto
{
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public string? Nombre { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<SeguimientoClientes> Seguimientos { get; set; } = new List<SeguimientoClientes>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public Proyecto()
    {

    }

    public Proyecto(Codigo proyecto, int idCliente)
    {
        Id = proyecto.Id;
        Nombre = proyecto.Descripcion;
        IdCliente = proyecto.Id;
    }
    public Proyecto(ProyectoDetalle proyecto)
    {
        Id = proyecto.Id;
        Nombre = proyecto.Nombre;
        IdCliente = proyecto.IdCliente;
    }
}
