﻿using HManagementLead.Entities;

namespace HManagementLead.Bll.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteDetalle> GetClienteByIdAsync(int id);

        Task<List<ClienteDetalle>> GetAllClientesAsync();

        Task<int> InsertClienteAsync(ClienteDetalle cliente);

        Task<ClienteDetalle> UpdateClienteAsync(ClienteDetalle cliente);

        Task DeleteClienteAsync(int id);

    }
}
