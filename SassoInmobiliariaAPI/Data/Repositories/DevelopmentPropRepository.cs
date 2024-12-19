using Microsoft.EntityFrameworkCore;
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

        public List<DevelopmentProp> GetAllDevProps()
        {
            return _context.Set<DevelopmentProp>()
                           .Include(d => d.Properties)
                           .ToList();
        }
    }
}