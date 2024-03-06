using HManagementLead.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HManagementLead.Data.Enitites
{
    public partial class Licitacion //Las clases en singular, por favor
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Tipo { get; set; }

        public virtual ICollection<LicitacionCliente> LicitacionesClientes { get; set; } = new List<LicitacionCliente>();
        public virtual ICollection<LicitacionProyecto> LicitacionesProyectos { get; set; } = new List<LicitacionProyecto>();

        public Licitacion() { }

        public Licitacion(int id, string nombre) 
        {
            this.Id = id;
            this.Nombre = nombre;
        }
        public Licitacion(LicitacionDetalle licitacion)
        {
            Id = licitacion.Id;
            Nombre = licitacion.Nombre;
            Tipo = licitacion.Tipo;
        }
    }
}
