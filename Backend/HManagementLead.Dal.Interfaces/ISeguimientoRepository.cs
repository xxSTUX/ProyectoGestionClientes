using HManagementLead.Entities;

namespace HManagementLead.Dal.Interfaces
{
    public  interface ISeguimientoRepository
    {
        Task<SeguimientoDetalle> GetSeguimientoByIdAsync(int id);

        Task<List<Codigo>> GetAllSeguimientoAsync();

        Task<int> InsertSeguimientoAsync(SeguimientoDetalle seguimiento);

        Task<SeguimientoDetalle> UpdateSeguimientoAsync(int id, SeguimientoDetalle seguimiento);

        Task DeleteSeguimientoByIdAsync(int id);
    }
}
