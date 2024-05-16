namespace SchoolWebApp.Data
{
    public interface IGenericRepository< T> where T : class
    {
        bool Create(T entity);
        List<T> Read();
        bool Update(T entity);
        bool Delete(T entity);
    }
}
