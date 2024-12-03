namespace SassoInmobiliariaAPI.Data.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        List<T> GetAll();
        T? GetById(int id);
        T Create(T entity);
        // void Delete(T entity); ----> no lo vamos a usar de momento, a lo sumo queda como metodo propio del repo de admin.
        void Update(T entity);
    }
}
