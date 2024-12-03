using SassoInmobiliariaAPI.Models.Entities;
using SassoInmobiliariaAPI.Services.DTOs;

namespace SassoInmobiliariaAPI.Services.Interfaces
{
    public interface IPropertyService
    {
        public Property Create(PropRequest request);
        public void Update(int id, PropRequest request);
        public Property GetById(int id);
        public List<Property> GetAll();
    }
}
