using SassoInmobiliariaAPI.Data.Interfaces;
using SassoInmobiliariaAPI.Data.Services;

namespace SassoInmobiliariaAPI.Data.Repositories
{
    public  abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ApplicationContext _context;

        protected BaseRepository(ApplicationContext context) 
        {
            _context = context;
        }
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        // -------------->  por ahora no vamos a eliminar registros de forma física

        //public void Delete(T entity)
        //{
        //    _context.Set<T>().Remove(entity);
        //    _context.SaveChanges();
        //}

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        
    }
}
