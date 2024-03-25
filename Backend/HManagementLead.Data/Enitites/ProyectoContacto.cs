using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{
    [PrimaryKey(nameof(ProyectoId), nameof(ContactoId))]
    [Index(nameof(ProyectoId), nameof(ContactoId))]
    public partial class ProyectoContacto
    {
        [Key]
        [Column(Order = 0)]
        public int ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; } = null!;
        [Key]
        [Column(Order = 1)]
        public int ContactoId { get; set; }
        public Contacto Contacto { get; set; } = null!;
    }
}
