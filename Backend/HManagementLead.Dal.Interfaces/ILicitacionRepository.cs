using HManagementLead.Entities;

namespace HManagementLead.Dal.Interfaces
{
    public  interface ILicitacionRepository
    {
        Task<LicitacionDetalle> GetLicitacionByIdAsync(int id);

        Task<List<Codigo>> GetAllLicitacionAsync();

        Task<int> InsertLicitacionAsync(LicitacionDetalle licitacion);

        Task<LicitacionDetalle> UpdateLicitacionAsync(int id, LicitacionDetalle licitacion);

        Task DeleteLicitacionAsync(int id);
    }
}
