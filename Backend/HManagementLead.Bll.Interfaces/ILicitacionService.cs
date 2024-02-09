using HManagementLead.Entities;

namespace HManagementLead.Bll.Interfaces
{
    public interface ILicitacionService
    {
        Task<LicitacionDetalle> GetLicitacionByIdAsync(int id);

        Task<List<Codigo>> GetAllLicitacionAsync();
    }
}
