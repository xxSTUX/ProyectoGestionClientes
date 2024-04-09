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
    public class AreaService : IAreaService
    {
        private readonly IAreaRepository _repository;
        public AreaService(IAreaRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public Task<List<Codigo>> GetAllAreaAsync()
        {
            return _repository.GetAllAreaAsync();
        }

        public Task<AreaDetalle> GetAreaByIdAsync(int id)
        {
            return _repository.GetAreaByIdAsync(id);
        }
    }
}
