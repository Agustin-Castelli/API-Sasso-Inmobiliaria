using SassoInmobiliariaAPI.Models.Entities;
using SassoInmobiliariaAPI.Services.DTOs;

namespace SassoInmobiliariaAPI.Services.Interfaces
{
    public interface IPropertyService
    {
        public Property Create(PropRequest request);
        public void Update(int id, PropRequest request);
        public Property GetById(int id);
        public List<Property> GetActiveProperties();
        public void DeleteProp(int id);
        public void RecoverProp(int id);
        public List<Property> GetAll();
    }
}
