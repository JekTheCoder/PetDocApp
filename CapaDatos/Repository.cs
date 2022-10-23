namespace CapaDatos
{
    public interface Repository<T>
    {
        T GetOne(int id);
        T[] GetAll();
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}
