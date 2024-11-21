using Microsoft.EntityFrameworkCore;
using SassoInmobiliariaAPI.Models.Entities;

namespace SassoInmobiliariaAPI.Data.Repositories
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Property> Propertys { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<DevelopmentProp> DevelopmentProps { get; set; }

        // Esto se puede usar para configurar el modelo, si es necesario  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de entidad específica  
            // modelBuilder.Entity<Product>().Property(p => p.Id).ValueGeneratedOnAdd();  
        }
    }
}
