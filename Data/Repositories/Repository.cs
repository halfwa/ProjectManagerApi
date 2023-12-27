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

        public async Task CreateAsync(T item)
        {
            await Set.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await Set.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Set.ToListAsync();
        }
        public async Task UpdateAsync(T item)
        {
            Set.Update(item);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAllAsync()
        {
            Set.RemoveRange(Set);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(T item)
        {
            Set.Remove(item);

            await _db.SaveChangesAsync();
        }
    }
}
