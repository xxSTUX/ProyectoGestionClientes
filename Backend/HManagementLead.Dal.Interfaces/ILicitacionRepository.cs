using HManagementLead.Entities;

namespace HManagementLead.Dal.Interfaces
{
    public  interface ILicitacionRepository
    {
        Task<LicitacionDetalle> GetLicitacionByIdAsync(int id);

        Task<List<Codigo>> GetAllLicitacionAsync();

        Task<int> InsertLicitacionAsync(LicitacionDetalle licitacion);
    }
}
