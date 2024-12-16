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

        //  <-------------------------->  METODOS RELACIONADOS AL CRUD  <-------------------------->

        public DevelopmentProp Create(DevPropRequest request)
        {
            var newObj = new DevelopmentProp();

            newObj.DevelopName = request.DevelopName;
            newObj.DevelopDescription = request.DevelopDescription;
            newObj.DevelopAdress = request.DevelopAdress;
            newObj.DevelopImage = request.DevelopImage;
            newObj.IsActive = true;
            newObj.Properties = request.Properties;

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
                obj.IsActive = true;
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

        public List<DevelopmentProp> GetActiveDevProps()
        {
            return _developmentPropRepository.GetAll().Where(p  => p.IsActive).ToList();
        }

        public void DeleteDevProp(int id)
        {
            var obj = _developmentPropRepository.GetById(id);

            if (obj == null) throw new NotFoundException(nameof(obj), id);
            else
            {
                obj.IsActive = false;
                _developmentPropRepository.Update(obj);
            }
        }

        public void RecoverDevProp(int id)
        {
            var obj = _developmentPropRepository.GetById(id);

            if (obj == null) throw new NotFoundException(nameof(obj), id);
            else
            {
                obj.IsActive = true;
                _developmentPropRepository.Update(obj);
            }
        }

        public List<DevelopmentProp> GetAll()
        {
            return _developmentPropRepository.GetAll();
        }


        //  <-------------------------->  OTROS MÉTODOS  <-------------------------->


        public void AddPropToDevelopment(int id, Property prop)
        {
            var devProp = _developmentPropRepository.GetById(id);

            if (devProp != null)
            {
                if (!devProp.Properties.Any(p => p.Id == prop.Id))
                {
                    devProp.Properties?.Add(prop);
                    _developmentPropRepository.Update(devProp);
                }
                else
                {
                    throw new ArgumentException($"La propiedad con Id {prop.Id} ya está asociada con el desarrollo con Id {id}.");
                }
            }
            else
            {
                throw new NotFoundException(nameof(devProp), id);
            }
        }

        public void RemovePropFromDevelopment(int id, Property prop)
        {
            var devProp = _developmentPropRepository.GetById(id);

            if (devProp != null)
            {
                if (devProp.Properties?.Contains(prop) == true)
                {
                    devProp.Properties.Remove(prop);
                    _developmentPropRepository.Update(devProp);
                }
                else
                {
                    throw new NotFoundException(nameof(prop), id);
                }
            }
            else
            {
                throw new NotFoundException(nameof(devProp), id);
            }
        }
    }
}
