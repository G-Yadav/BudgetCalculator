namespace com.gaurav.main.infrastructure.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        void Add(T value);
        void Update(T value);
        void Delete(int id);
        T? Find(int id);
        IEnumerable<T>? Get();
        void Save();
    }
}