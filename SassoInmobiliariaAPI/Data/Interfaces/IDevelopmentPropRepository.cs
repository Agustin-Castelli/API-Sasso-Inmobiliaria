﻿using SassoInmobiliariaAPI.Models.Entities;

namespace SassoInmobiliariaAPI.Data.Interfaces
{
    public interface IDevelopmentPropRepository : IBaseRepository<DevelopmentProp>
    {
        public List<DevelopmentProp> GetAllDevProps();
    }
}
