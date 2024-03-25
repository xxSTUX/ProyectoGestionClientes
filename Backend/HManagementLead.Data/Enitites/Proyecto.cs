using HManagementLead.Data.Enitites;
using HManagementLead.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HManagementLead.Data;

public partial class Proyecto
{
    [Key]
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public string? Nombre { get; set; }

    public int Estado { get; set; }
    public string Tipo { get; set; }
    public bool Eliminado { get; set; } = false;

    public virtual ICollection<FacturacionProyecto> FacturacionesProyectos { get; set; } = new List<FacturacionProyecto>();
    public virtual ICollection<LicitacionProyecto> LicitacionesProyectos { get; set; } = new List<LicitacionProyecto>();
    public virtual ICollection<ProyectoContacto> ProyectosContactos { get; set; } = new List<ProyectoContacto>();
    public virtual ICollection<PuestoProyecto> PuestosProyectos { get; set; } = new List<PuestoProyecto>();
    public virtual ICollection<SeguimientoProyecto> SeguimientosProyectos { get; set; } = new List<SeguimientoProyecto>();

    //public virtual ICollection<SeguimientoProyecto> Seguimientos { get; set; } = new List<SeguimientoProyecto>();
    //public virtual ICollection<LicitacionProyecto> Licitaciones { get; set; } = new List<LicitacionProyecto>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public Proyecto()
    {

    }

    public Proyecto(ProyectoDetalle proyecto)
    {
        Id = proyecto.Id;
        Nombre = proyecto.Nombre;
        ClienteId = proyecto.IdCliente;
        Estado = proyecto.Estado;
        Tipo = proyecto.Tipo;
        Eliminado = proyecto.Eliminado;
        foreach (var seguimientoCliente in proyecto.SeguimientoProyecto)
        {
            if (!seguimientoCliente.IdModelo.Equals(0))
            {
                SeguimientosProyectos.Add(new SeguimientoProyecto(Id, seguimientoCliente.IdModelo));
            }

        }
    }
}
