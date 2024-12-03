using SassoInmobiliariaAPI.Models.Entities;
using SassoInmobiliariaAPI.Services.DTOs;

namespace SassoInmobiliariaAPI.Services.Interfaces
{
    public interface IAdminService
    {
        public Admin Create(AdminRequest request);
        public void Update(int id, AdminRequest request);
        public void Delete(int id);
        public Admin GetById(int id);
        public List<Admin> GetAll();
    }
}
