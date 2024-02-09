using HManagementLead.Entities;

namespace HManagementLead.Dal.Interfaces
{
    public  interface ISeguimientoRepository
    {
        Task<SeguimientoDetalle> GetSeguimientoByIdAsync(int id);

        Task<List<Codigo>> GetAllSeguimientoAsync();
    }
}
