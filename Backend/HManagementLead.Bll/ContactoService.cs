﻿using HManagementLead.Bll.Interfaces;
using HManagementLead.Dal.Interfaces;
using HManagementLead.Entities;

namespace HManagementLead.Bll
{
    public class ContactoService : IContactoService
    {
        private readonly IContactoRepository _repository;
        public ContactoService(IContactoRepository repository) 
        { 
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<List<ContactoDetalle>> GetAllContactoAsync()
        {
            return _repository.GetAllContactoAsync();
        }

        public Task<ContactoDetalle> GetContactoByIdAsync(int id)
        {
            return _repository.GetContactoByIdAsync(id);
        }

       public Task<ContactoDetalle> UpdateEliminadoAsync(int id)
        {
            return _repository.UpdateEliminadoAsync(id);
        }

    }
}
