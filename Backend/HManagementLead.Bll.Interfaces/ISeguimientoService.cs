using HManagementLead.Entities;

namespace HManagementLead.Bll.Interfaces
{
    public interface ISeguimientoService
    {
        Task<SeguimientoDetalle> GetSeguimientoByIdAsync(int id);

        Task<List<Codigo>> GetAllSeguimientoAsync();

        Task<int> InsertSeguimientoAsync(SeguimientoDetalle cliente);

        Task<SeguimientoDetalle> UpdateSeguimientoAsync(SeguimientoDetalle cliente);

        Task DeleteSeguimientoAsync(int id);

    }
}
