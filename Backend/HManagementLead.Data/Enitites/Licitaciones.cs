using HManagementLead.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HManagementLead.Data.Enitites
{
    public partial class Licitaciones
    {
        public int Id { get; set; }
        public string Nombre{ get; set; }

        public Licitaciones() { }

        public Licitaciones(int id, string nombre) 
        {
            this.Id = id;
            this.Nombre = nombre;
        }
        public Licitaciones(LicitacionDetalle licitacion)
        {
            Id = licitacion.Id;
            Nombre = licitacion.Nombre;
            
        }
    }
}
