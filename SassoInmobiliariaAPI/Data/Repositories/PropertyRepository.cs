using SassoInmobiliariaAPI.Data.Interfaces;
using SassoInmobiliariaAPI.Data.Services;
using SassoInmobiliariaAPI.Models.Entities;

namespace SassoInmobiliariaAPI.Data.Repositories
{
    public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
