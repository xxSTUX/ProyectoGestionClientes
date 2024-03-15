using HManagementLead.Data.Enitites;
using HManagementLead.Entities;
using Microsoft.EntityFrameworkCore;

namespace HManagementLead.Data;

public partial class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;

    public bool Eliminado { get; set; } = false;


    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
    public virtual ICollection<ContactoCliente> ContactosClientes { get; set; } = new List<ContactoCliente>();
    public virtual ICollection<FacturacionCliente> FacturacionesClientes { get; set; } = new List<FacturacionCliente>();
    public virtual ICollection<LicitacionCliente> LicitacionesClientes { get; set; } = new List<LicitacionCliente>();
    public virtual ICollection<PuestoCliente> PuestosClientes { get; set; } = new List<PuestoCliente>();
    public virtual ICollection<SeguimientoCliente> SeguimientosClientes { get; set; } = new List<SeguimientoCliente>();

    //public virtual ICollection<SeguimientoCliente> Seguimientos { get; set; } = new List<SeguimientoCliente>();
    //public virtual ICollection<LicitacionCliente> Licitaciones { get; set; } = new List<LicitacionCliente>();

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
                SeguimientosClientes.Add(new SeguimientoCliente(Id, seguimientoCliente.IdModelo));
            }
            
        }
    }


}
