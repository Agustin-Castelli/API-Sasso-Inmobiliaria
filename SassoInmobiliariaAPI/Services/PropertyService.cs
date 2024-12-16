using Microsoft.AspNetCore.Http.HttpResults;
using SassoInmobiliariaAPI.Data.Interfaces;
using SassoInmobiliariaAPI.Models.Entities;
using SassoInmobiliariaAPI.Models.Exceptions;
using SassoInmobiliariaAPI.Services.DTOs;
using SassoInmobiliariaAPI.Services.Interfaces;

namespace SassoInmobiliariaAPI.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public Property Create(PropRequest request)
        {
            var newObj = new Property();

            newObj.Name = request.Name;
            newObj.Description = request.Description;
            newObj.Adress = request.Adress;
            newObj.Price = request.Price;
            newObj.Image = request.Image;
            newObj.Area = request.Area;
            newObj.Baths = request.Baths;
            newObj.Bedrooms = request.Bedrooms;
            newObj.Latitude = request.Latitude;
            newObj.Longitude = request.Longitude;
            newObj.IsActive = true;
            newObj.IsDistingued = request.IsDistingued;
            newObj.IsUpToCredit = request.IsUpToCredit;
            newObj.TypeOfOffer = request.TypeOfOffer;
            newObj.TypeOfProp = request.TypeOfProp;

            return _propertyRepository.Create(newObj);
        }

        public void Update(int id, PropRequest request)
        {
            var prop = _propertyRepository.GetById(id);

            if (prop == null)
            {
                throw new NotFoundException(nameof(request), id);
            }
            else
            {
                if (request.Name != string.Empty) prop.Name = request.Name;
                if (request.Description != string.Empty) prop.Description = request.Description;
                if (request.Adress != string.Empty) prop.Adress = request.Adress;
                if (request.Price >= 0) prop.Price = request.Price;
                if (request.Image != string.Empty) prop.Image = request.Image;
                if (request.Area > 0) prop.Area = request.Area;
                if (request.Baths > 0) prop.Baths = request.Baths;
                if (request.Bedrooms > 0) prop.Bedrooms = request.Bedrooms;
                if (request.Latitude != 0) prop.Latitude = request.Latitude;
                if (request.Longitude != 0) prop.Longitude = request.Longitude;
                prop.IsActive = true;
                prop.IsDistingued = request.IsDistingued;
                prop.IsUpToCredit = request.IsUpToCredit;
                prop.TypeOfOffer = request.TypeOfOffer;
                prop.TypeOfProp = request.TypeOfProp;

                _propertyRepository.Update(prop);
            }
        }

        public Property GetById(int id)
        {
            var obj = _propertyRepository.GetById(id);

            if (obj == null)
            {
                throw new NotFoundException(nameof(obj), id);
            }
            else
            {
                return obj;
            }
        }

        public void DeleteProp(int id)
        {
            var obj = _propertyRepository.GetById(id);

            if (obj == null)
            {
                throw new NotFoundException(nameof(obj), id);
            }
            else
            {
                obj.IsActive = false;
                _propertyRepository.Update(obj);
            }
        }

        public void RecoverProp(int id)
        {
            var obj = _propertyRepository.GetById(id);

            if (obj == null)
            {
                throw new NotFoundException(nameof(obj), id);
            }
            else
            {
                obj.IsActive = true;
                _propertyRepository.Update(obj);
            }
        }

        public List<Property> GetActiveProperties()
        {
            var propertiesFiltered = _propertyRepository.GetAll().Where(p => p.IsActive).ToList();

            return propertiesFiltered;
        }

        public List<Property> GetAll()
        {
            return _propertyRepository.GetAll();
        }
    }
}
