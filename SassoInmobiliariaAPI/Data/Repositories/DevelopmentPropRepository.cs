using SassoInmobiliariaAPI.Data.Interfaces;
using SassoInmobiliariaAPI.Data.Services;
using SassoInmobiliariaAPI.Models.Entities;

namespace SassoInmobiliariaAPI.Data.Repositories
{
    public class DevelopmentPropRepository : BaseRepository<DevelopmentProp>, IDevelopmentPropRepository
    {
        public DevelopmentPropRepository(ApplicationContext context) : base(context)
        {

        }
    }
}