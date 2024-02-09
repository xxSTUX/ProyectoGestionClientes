using HManagementLead.Data.Enitites;
using HManagementLead.Entities;
using System.Text.Json.Serialization;

namespace HManagementLead.Data;

public partial class Proyecto
{
    public int Id { get; set; }

    public int Cliente_id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<SeguimientoProyectos> Seguimientos { get; set; } = new List<SeguimientoProyectos>();
    public virtual ICollection<LicitacionProyectos> Licitaciones { get; set; } = new List<LicitacionProyectos>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public Proyecto()
    {

    }

    public Proyecto(ProyectoDetalle proyecto)
    {
        Id = proyecto.Id;
        Nombre = proyecto.Nombre;
        Cliente_id = proyecto.IdCliente;
        foreach (var seguimientoCliente in proyecto.SeguimientoProyecto)
        {
            if (!seguimientoCliente.IdModelo.Equals(0))
            {
                Seguimientos.Add(new SeguimientoProyectos(Id, seguimientoCliente.IdModelo));
            }

        }
    }
}
