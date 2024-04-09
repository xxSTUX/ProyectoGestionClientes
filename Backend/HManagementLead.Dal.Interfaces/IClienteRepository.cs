﻿using HManagementLead.Data;
using HManagementLead.Entities;

namespace HManagementLead.Dal.Interfaces
{
    public  interface IClienteRepository
    {
        Task<ClienteDetalle> GetClienteByIdAsync(int id);

        Task<List<ClienteDetalle>> GetAllClientesAsync();

        Task<int> InsertClienteAsync(ClienteDetalle cliente);

        Task<ClienteDetalle> UpdateClienteAsync(ClienteDetalle cliente);
        //Arbol
        Task<List<ClienteSimplificado>> GetAllClientesCompletoAsync();

        Task <ClienteDetalle> DeleteClienteAsync(int id);

        Task<bool> ClienteExistsAsync(string nombre);

        Task<ClienteDetalle> InsertProyectoInClienteAsync(int id, ProyectoDetalle proyecto);

        Task<ClienteDetalle> InsertSeguimientoInClienteAsync(int id, SeguimientoDetalle seguimiento);

        Task<ClienteDetalle> InsertLicitacionInClienteAsync(int id, LicitacionDetalle seguimiento);
        Task<ClienteDetalle> InsertContactoInClienteAsync(int id, ContactoDetalle contacto);

        Task<ClienteDetalle> InsertAreaInClienteAsync(int id, AreaDetalle area);
        Task<List<Codigo>> GetAllClientesAsyncToCodigo();
        Task<ClienteDetalle> GetClienteByNombre(string nombre);
    }
}
