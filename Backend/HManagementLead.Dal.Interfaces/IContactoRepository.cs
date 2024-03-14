using HManagementLead.Entities;

namespace HManagementLead.Dal.Interfaces
{
    public  interface IContactoRepository
    {
        Task<ContactoDetalle> GetContactoByIdAsync(int id);

        Task<List<ContactoDetalle>> GetAllContactoAsync();
        Task<ContactoDetalle> UpdateEliminadoAsync(int id);
    }
}
