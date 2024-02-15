using HManagementLead.Entities;

namespace HManagementLead.Bll.Interfaces
{
    public interface ISeguimientoService
    {
        Task<SeguimientoDetalle> GetSeguimientoByIdAsync(int id);

        Task<List<Codigo>> GetAllSeguimientoAsync();

        Task<int> InsertSeguimientoAsync(SeguimientoDetalle seguimiento);

        Task<SeguimientoDetalle> UpdateSeguimientoAsync(int id, SeguimientoDetalle seguimiento);

        Task DeleteSeguimientoByIdAsync(int id);
    }
}
