using SassoInmobiliariaAPI.Models.Entities;

namespace SassoInmobiliariaAPI.Data.Interfaces
{
    public interface IAdminRepository : IBaseRepository<Admin>
    {
        public void Delete(Admin admin);
    }
}
