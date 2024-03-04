using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HManagementLead.Bll.Interfaces;
using HManagementLead.Dal.Interfaces;
using HManagementLead.Entities;

namespace HManagementLead.Bll
{
    public class FacturacionService : IFacturacionService
    {
        private readonly IFacturacionRepository _repository;
        public FacturacionService(IFacturacionRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<List<Codigo>> GetAllFacturacionAsync()
        {
            return _repository.GetAllFacturacionAsync();
        }

        public Task<FacturacionDetalle> GetFacturacionByIdAsync(int id)
        {
            return _repository.GetFacturacionByIdAsync(id);
        }
    }
}
