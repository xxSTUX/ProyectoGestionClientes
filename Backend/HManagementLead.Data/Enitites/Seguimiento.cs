using HManagementLead.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HManagementLead.Data.Enitites
{
    public partial class Seguimiento
    {
        [Key]
        public int Id { get; set; }
        public string Usuario{ get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public bool Eliminado { get; set; } = false;


        public virtual ICollection<SeguimientoCliente> SeguimientosClientes { get; set; } = new List<SeguimientoCliente>();
        public virtual ICollection<SeguimientoProyecto> SeguimientosProyectos { get; set; } = new List<SeguimientoProyecto>();

        public Seguimiento() { }

        public Seguimiento(int id, string nombre) 
        {
            this.Id = id;
            this.Usuario = nombre;
        }
        public Seguimiento(SeguimientoDetalle seguimiento)
        {
            Id = seguimiento.Id;
            Usuario = seguimiento.Usuario;
            Fecha = seguimiento.Fecha;
            Observaciones = seguimiento.Observaciones;     
        }
    }
}
