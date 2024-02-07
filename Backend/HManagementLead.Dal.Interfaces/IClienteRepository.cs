﻿using HManagementLead.Entities;

namespace HManagementLead.Dal.Interfaces
{
    public  interface IClienteRepository
    {
        Task<ClienteDetalle> GetClienteByIdAsync(int id);

        Task<List<ClienteDetalle>> GetAllClientesAsync();

        Task<int> InsertClienteAsync(ClienteDetalle cliente);

        Task<ClienteDetalle> UpdateClienteAsync(ClienteDetalle cliente);

        Task DeleteClienteAsync(int id);

    }
}