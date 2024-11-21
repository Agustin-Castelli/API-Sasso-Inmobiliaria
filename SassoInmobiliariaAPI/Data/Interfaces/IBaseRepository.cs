namespace SassoInmobiliariaAPI.Data.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        List<T> GetAll();
        T? GetById(int id);
        T Create(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
