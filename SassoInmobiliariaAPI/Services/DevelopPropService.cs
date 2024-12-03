using Microsoft.AspNetCore.Http.HttpResults;
using SassoInmobiliariaAPI.Data.Interfaces;
using SassoInmobiliariaAPI.Models.Entities;
using SassoInmobiliariaAPI.Models.Exceptions;
using SassoInmobiliariaAPI.Services.DTOs;
using SassoInmobiliariaAPI.Services.Interfaces;

namespace SassoInmobiliariaAPI.Services
{
    public class DevelopPropService : IDevelopPropService
    {
        private readonly IDevelopmentPropRepository _developmentPropRepository;

        public DevelopPropService(IDevelopmentPropRepository developmentPropRepository)
        {
            _developmentPropRepository = developmentPropRepository;
        }

        public DevelopmentProp Create(DevPropRequest request)
        {
            var newObj = new DevelopmentProp();

            newObj.DevelopName = request.DevelopName;
            newObj.DevelopDescription = request.DevelopDescription;
            newObj.DevelopAdress = request.DevelopAdress;
            newObj.DevelopImage = request.DevelopImage;

            return _developmentPropRepository.Create(newObj);
        }

        public void Update(int id, DevPropRequest request)
        {
            var obj = _developmentPropRepository.GetById(id);

            if (obj == null)
            {
                throw new NotFoundException(nameof(request), id);
            }

            else
            {
                obj.DevelopName = request.DevelopName;
                obj.DevelopDescription = request.DevelopDescription;
                obj.DevelopAdress = request.DevelopAdress;
                obj.DevelopImage = request.DevelopImage;
                obj.Properties = request.Properties;

                _developmentPropRepository.Update(obj);
            }
        }

        public DevelopmentProp GetById(int id)
        {
            var obj = _developmentPropRepository.GetById(id);

            if (obj == null) throw new NotFoundException(nameof(obj), id);

            else return obj;
        }

        public List<DevelopmentProp> GetAll()
        {
            return _developmentPropRepository.GetAll();
        }
    }
}
