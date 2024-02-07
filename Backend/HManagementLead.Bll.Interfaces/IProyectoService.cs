﻿using HManagementLead.Entities;

namespace HManagementLead.Bll.Interfaces
{
    public interface IProyectoService
    {
        Task<ProyectoDetalle> GetProyectoByIdAsync(int id);

        Task<List<ProyectoDetalle>> GetAllProyectosAsync();

        Task<int> InsertProyectoAsync(ProyectoDetalle cliente);

        Task<ProyectoDetalle> UpdateProyectoAsync(ProyectoDetalle proyecto);

        Task DeleteProyectoAsync(int id);

    }
}