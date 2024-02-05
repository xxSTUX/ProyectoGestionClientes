using HManagementLead.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HManagementLead.Data.Enitites
{
    public partial class Seguimiento
    {
        public int Id { get; set; }
        public DateTime Fecha{ get; set; }
        public virtual ICollection<SeguimientoClientes> Seguimientos { get; set; } = new List<SeguimientoClientes>();


        public Seguimiento() { }

        public Seguimiento(int id, DateTime Fecha) 
        {
            this.Id = id;
            this.Fecha = Fecha;
        }
        public Seguimiento(SeguimientoDetalle seguimiento)
        {
            Id = seguimiento.Id;
            Fecha = seguimiento.Fecha;
            
        }
    }
}
