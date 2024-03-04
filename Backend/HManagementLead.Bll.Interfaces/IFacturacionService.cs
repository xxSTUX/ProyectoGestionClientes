using HManagementLead.Entities;

namespace HManagementLead.Bll.Interfaces
{
    public interface IFacturacionService
    {
        Task<FacturacionDetalle> GetFacturacionByIdAsync(int id);

        Task<List<Codigo>> GetAllFacturacionAsync();
    }
}
