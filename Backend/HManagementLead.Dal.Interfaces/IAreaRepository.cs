using HManagementLead.Entities;

namespace HManagementLead.Dal.Interfaces
{
    public interface IAreaRepository
    {
        Task<AreaDetalle> GetAreaByIdAsync(int id);

        Task<List<Codigo>> GetAllAreaAsync();
    }
}
