using SassoInmobiliariaAPI.Models.Entities;
using SassoInmobiliariaAPI.Services.DTOs;

namespace SassoInmobiliariaAPI.Services.Interfaces
{
    public interface IDevelopPropService
    {
        public DevelopmentProp Create(DevPropRequest request);
        public void Update(int id, DevPropRequest request);
        public DevelopmentProp GetById(int id);
        public List<DevelopmentProp> GetAll();
    }
}
