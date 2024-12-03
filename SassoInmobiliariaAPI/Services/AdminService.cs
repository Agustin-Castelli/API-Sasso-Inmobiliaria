using SassoInmobiliariaAPI.Data.Interfaces;
using SassoInmobiliariaAPI.Models.Entities;
using SassoInmobiliariaAPI.Models.Exceptions;
using SassoInmobiliariaAPI.Services.DTOs;
using SassoInmobiliariaAPI.Services.Interfaces;

namespace SassoInmobiliariaAPI.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public Admin Create(AdminRequest request)
        {
            var newObj = new Admin();
            
            newObj.Username = request.Username;
            newObj.Password = request.Password;

            return _adminRepository.Create(newObj);
        }

        public void Update(int id, AdminRequest request)
        {
            var obj = _adminRepository.GetById(id);

            if (obj == null)
            {
                throw new NotFoundException(nameof(request), id);
            }

            if (obj.Username != string.Empty) obj.Username = request.Username; 
            if (obj.Password != string.Empty) obj.Password = request.Password;

            _adminRepository.Update(obj);
        }

        public void Delete(int id)
        {
            var admin = _adminRepository.GetById(id);

            if (admin == null)
            {
                throw new NotFoundException(nameof(admin), id);
            }

            _adminRepository.Delete(admin);
        }

        public Admin GetById(int id)
        {
            var obj = _adminRepository.GetById(id);

            if (obj == null)
            {
                throw new NotFoundException(nameof(obj), id);
            }

            else
            {
                return obj;
            }
        }

        public List<Admin> GetAll()
        {
            return _adminRepository.GetAll();
        }
    }
}
