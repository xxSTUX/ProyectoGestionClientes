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
    public class PuestoService : IPuestoService
    {
        private readonly IPuestoRepository _repository;
        public PuestoService(IPuestoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public Task<List<Codigo>> GetAllPuestoAsync()
        {
            return _repository.GetAllPuestoAsync();
        }

        public Task<PuestoDetalle> GetPuestoByIdAsync(int id)
        {
            return _repository.GetPuestoByIdAsync(id);
        }
    }
}
