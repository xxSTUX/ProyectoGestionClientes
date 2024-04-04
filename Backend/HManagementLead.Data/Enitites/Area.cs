using HManagementLead.Data.Enitites;
using HManagementLead.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HManagementLead.Data;

public partial class Area
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; }

    public int ClienteId { get; set; }
    public string Email { get; set; }
    public string? Responsable { get; set; }
    public bool Eliminado { get; set; } = false;
    public virtual ICollection<SeguimientoArea> SeguimientosArea { get; set; } = new List<SeguimientoArea>();

    //public virtual ICollection<SeguimientoProyecto> Seguimientos { get; set; } = new List<SeguimientoProyecto>();
    //public virtual ICollection<LicitacionProyecto> Licitaciones { get; set; } = new List<LicitacionProyecto>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public Area()
    {

    }

    public Area(AreaDetalle area)
    {
        Id = area.Id;
        Nombre = area.Nombre;
        ClienteId = area.IdCliente;
        Email = area.Email;
        Responsable = area.Responsable;
        Eliminado = area.Eliminado;
        foreach (var seguimientoArea in area.SeguimientoArea)
        {
            if (!seguimientoArea.IdModelo.Equals(0))
            {
                SeguimientosArea.Add(new SeguimientoArea(Id, seguimientoArea.IdModelo));
            }

        }
    }
}
