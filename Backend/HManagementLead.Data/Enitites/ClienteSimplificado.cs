using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HManagementLead.Data.Enitites;
using HManagementLead.Entities;

namespace HManagementLead.Data
{
    public partial class ClienteSimplificado
    {
        [Key]
        public int ClienteId { get; set; }
        public String Nombre { get; set; } = null!;
        public List<ProyectoSimplificado> Proyectos { get; set; } = new List<ProyectoSimplificado>();
        public List<SeguimientoSimplificado> Seguimientos { get; set; } = new List<SeguimientoSimplificado>();
        public List<LicitacionSimplificado> Licitaciones { get; set; } = new List<LicitacionSimplificado>();
    }
}