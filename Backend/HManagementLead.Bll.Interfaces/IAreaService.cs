using HManagementLead.Entities;

namespace HManagementLead.Bll.Interfaces
{
    public interface IAreaService
    {
        Task<AreaDetalle> GetAreaByIdAsync(int id);

        Task<List<Codigo>> GetAllAreaAsync();
    }
}
