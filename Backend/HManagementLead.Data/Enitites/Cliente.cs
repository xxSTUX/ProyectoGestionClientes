using HManagementLead.Data.Enitites;
using HManagementLead.Entities;

namespace HManagementLead.Data;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
    public virtual ICollection<SeguimientoClientes> Seguimientos { get; set; } = new List<SeguimientoClientes>();

    public Cliente()
    {

    }

    public Cliente(ClienteDetalle cliente)
    {
        Id = cliente.Id;
        Nombre = cliente.Nombre;
        foreach (var proyecto in cliente.Proyectos)
        {
            if (!proyecto.Id.Equals(0))
            {
                Proyectos.Add(new Proyecto(proyecto));
            }
        }
        foreach (var seguimientoCliente in cliente.SeguimientoCliente)
        {
            if (!seguimientoCliente.IdModelo.Equals(0))
            {
                Seguimientos.Add(new SeguimientoClientes(Id, seguimientoCliente.IdModelo));
            }
            
        }
    }


}
