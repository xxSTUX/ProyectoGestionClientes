using HManagementLead.Entities;

namespace HManagementLead.Bll.Interfaces
{
    public interface ISeguimientoService
    {
        Task<SeguimientoDetalle> GetSeguimientoByIdAsync(int id);

        Task<List<Codigo>> GetAllSeguimientoAsync();
    }
}
