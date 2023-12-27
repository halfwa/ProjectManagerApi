using ProjectManagerApi.Models.Employees;
using ProjectManagerApi.Data.Repository;

namespace ProjectManagerApi.Data.Repositories.Implementations
{
    public class PositionsRepository : Repository<Position>
    {
        public PositionsRepository(AppDbContext db) : base(db) { }
    }
}
