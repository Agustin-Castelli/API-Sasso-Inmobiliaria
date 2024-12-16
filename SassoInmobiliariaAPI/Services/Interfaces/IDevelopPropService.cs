using SassoInmobiliariaAPI.Models.Entities;
using SassoInmobiliariaAPI.Services.DTOs;

namespace SassoInmobiliariaAPI.Services.Interfaces
{
    public interface IDevelopPropService
    {
        public DevelopmentProp Create(DevPropRequest request);
        public void Update(int id, DevPropRequest request);
        public void DeleteDevProp(int id);
        public void RecoverDevProp(int id);
        public DevelopmentProp GetById(int id);
        public List<DevelopmentProp> GetActiveDevProps();
        public List<DevelopmentProp> GetAll();


        public void AddPropToDevelopment(int id, Property prop);
        public void RemovePropFromDevelopment(int id, Property prop);

    }
}
