using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{
    public class Contactos
    {
        public int Id { get; set; }

        public string cargo { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
    }
}
