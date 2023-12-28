namespace ProjectManagerApi
{
    public interface IRepository<T> where T : class
    {
        Task<bool> SaveChangesAsync();

        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<bool> CreateAsync(T item);
        Task<bool> UpdateAsync(T item);
        Task<bool> DeleteAsync(T item);
        Task<bool> DeleteAllAsync();

    }
}