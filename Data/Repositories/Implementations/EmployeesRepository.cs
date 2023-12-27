using ProjectManagerApi.Models.Employees;
using ProjectManagerApi.Data.Repository;

namespace ProjectManagerApi.Data.Repositories.Implementations
{
    public class EmployeesRepository : Repository<Employee>
    {
        public EmployeesRepository(AppDbContext db) : base(db) { }
    }
}
