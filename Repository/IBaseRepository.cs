namespace Repository
{
    public interface IBaseRepository<T> : IDisposable
    {
        IEnumerable<T> Select();
        T? Select(Guid id);
        void Insert(T entity);
        void Update(Guid id, T entity);
        void Delete(Guid id);
        void Save();
    }
}
