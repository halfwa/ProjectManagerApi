using ProjectManagerApi.Models.Services;
using ProjectManagerApi.Data.Repository;

namespace ProjectManagerApi.Data.Repositories.Implementations
{
    public class ServicesRepository : Repository<Service>
    {
        public ServicesRepository(AppDbContext db) : base(db) { }
    }
}
