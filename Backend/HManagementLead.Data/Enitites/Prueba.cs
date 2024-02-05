using HManagementLead.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HManagementLead.Data.Enitites
{
    public partial class Prueba
    {
        public int Id { get; set; }
        public string? Accion { get; set; } 
        public string? Texto { get; set; }

        public Prueba()
        {

        }

        public Prueba(int Id, string Accion, string Texto)
        {
            this.Id = Id;
            this.Accion = Accion;
            this.Texto = Texto;
        }
    }
}
