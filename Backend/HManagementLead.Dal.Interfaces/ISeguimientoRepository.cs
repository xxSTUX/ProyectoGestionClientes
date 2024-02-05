using HManagementLead.Entities;

namespace HManagementLead.Dal.Interfaces
{
    public  interface ISeguimientoRepository
    {
        Task<SeguimientoDetalle> GetSeguimientoByIdAsync(int id);

        Task<List<Codigo>> GetAllSeguimientoAsync();

        Task<int> InsertSeguimientoAsync(SeguimientoDetalle cliente);

        Task<SeguimientoDetalle> UpdateSeguimientoAsync(SeguimientoDetalle cliente);

        Task DeleteSeguimientoAsync(int id);

    }
}
