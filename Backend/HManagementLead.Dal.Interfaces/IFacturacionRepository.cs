using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HManagementLead.Entities;

namespace HManagementLead.Dal.Interfaces
{
    public interface IFacturacionRepository
    {
        Task<FacturacionDetalle> GetFacturacionByIdAsync(int id);

        Task<List<Codigo>> GetAllFacturacionAsync();
    }
}

