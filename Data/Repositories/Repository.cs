using Microsoft.EntityFrameworkCore;


namespace ProjectManagerApi.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _db;

        public DbSet<T> Set
        {
            get;
            private set;
        }

        public Repository(AppDbContext db)
        {
            _db = db;
            Set = _db.Set<T>();
        }

        public async Task<bool> CreateAsync(T item)
        {
            await Set.AddAsync(item);
            return await SaveChangesAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await Set.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Set.ToListAsync();
        }

        public async Task<bool> UpdateAsync(T item)
        {
            Set.Update(item);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAllAsync()
        {
            Set.RemoveRange(Set);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(T item)
        {
            Set.Remove(item);
            return await SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
