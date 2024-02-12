﻿using HManagementLead.Bll.Interfaces;
using HManagementLead.Dal.Interfaces;
using HManagementLead.Entities;

namespace HManagementLead.Bll
{
    public class LicitacionService : ILicitacionService
    {
        private readonly ILicitacionRepository _repository;
        public LicitacionService(ILicitacionRepository repository) 
        { 
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<List<Codigo>> GetAllLicitacionAsync()
        {
            return _repository.GetAllLicitacionAsync();
        }

        public Task<LicitacionDetalle> GetLicitacionByIdAsync(int id)
        {
            return _repository.GetLicitacionByIdAsync(id);
        }
    }
}