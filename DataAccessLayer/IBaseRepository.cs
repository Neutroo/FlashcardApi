namespace DataAccessLayer
{
    public interface IBaseRepository<T> : IDisposable
    {
        IEnumerable<T> Select();
        IEnumerable<T> Select(string theme);
        T? Select(Guid id);
        void Insert(T entity);
        void Update(Guid id, T entity);
        void Delete(Guid id);
        void Save();
    }
}
