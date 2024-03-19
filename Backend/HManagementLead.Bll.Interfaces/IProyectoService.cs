using HManagementLead.Entities;

namespace HManagementLead.Bll.Interfaces
{
    public interface IProyectoService
    {
        Task<ProyectoDetalle> GetProyectoByIdAsync(int id);

        Task<List<ProyectoDetalle>> GetAllProyectosAsync();

        Task<int> InsertProyectoAsync(ProyectoDetalle cliente);

        Task<ProyectoDetalle> UpdateProyectoAsync(ProyectoDetalle proyecto);

        Task DeleteProyectoAsync(int id);

        Task<ProyectoDetalle> InsertSeguimientoInProyectoAsync(int id, SeguimientoDetalle seguimiento);
        Task<ProyectoDetalle> UpdateEliminadoAsync(int id);
        Task<List<EstadoProyectoDetalle>> GetEstadoPoryectos();
    }
}
