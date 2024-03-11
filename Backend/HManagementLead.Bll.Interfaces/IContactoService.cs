using HManagementLead.Entities;

namespace HManagementLead.Bll.Interfaces
{
    public interface IContactoService
    {
        Task<ContactoDetalle> GetContactoByIdAsync(int id);

        Task<List<ContactoDetalle>> GetAllContactoAsync();
    }
}
