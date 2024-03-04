using HManagementLead.Entities;

namespace HManagementLead.Bll.Interfaces
{
    public interface IPuestoService
    {
        Task<PuestoDetalle> GetPuestoByIdAsync(int id);

        Task<List<Codigo>> GetAllPuestoAsync();
    }
}
