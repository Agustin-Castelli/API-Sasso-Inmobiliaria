using SassoInmobiliariaAPI.Data.Interfaces;
using SassoInmobiliariaAPI.Data.Services;
using SassoInmobiliariaAPI.Models.Entities;

namespace SassoInmobiliariaAPI.Data.Repositories
{
    public class AdminRepository : BaseRepository<Admin>, IAdminRepository
    {
        public AdminRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
