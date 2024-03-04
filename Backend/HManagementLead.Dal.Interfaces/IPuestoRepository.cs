using HManagementLead.Entities;

namespace HManagementLead.Dal.Interfaces
{
    public interface IPuestoRepository
    {
        Task<PuestoDetalle> GetPuestoByIdAsync(int id);

        Task<List<Codigo>> GetAllPuestoAsync();
    }
}
