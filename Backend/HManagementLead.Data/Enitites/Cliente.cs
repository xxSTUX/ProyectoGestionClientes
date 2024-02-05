using HManagementLead.Data.Enitites;
using HManagementLead.Entities;

namespace HManagementLead.Data;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;
    public Boolean Seguimiento { get; set; }

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
            Proyectos.Add(new Proyecto(proyecto, cliente.Id));
        }
        foreach (var seguimientoCliente in cliente.Seguimientos)
        {
            Seguimientos.Add(new SeguimientoClientes(seguimientoCliente.IdSuperior,seguimientoCliente.IdModelo));
        }
    }


}
