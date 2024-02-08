using HManagementLead.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HManagementLead.Data.Enitites
{
    public partial class Seguimientos
    {
        public int Id { get; set; }
        public string Nombre{ get; set; }

        public Seguimientos() { }

        public Seguimientos(int id, string nombre) 
        {
            this.Id = id;
            this.Nombre = nombre;
        }
        public Seguimientos(SeguimientoDetalle seguimiento)
        {
            Id = seguimiento.Id;
            Nombre = seguimiento.Nombre;
            
        }
    }
}
