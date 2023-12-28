using ProjectManagerApi.Models.Employees;
using ProjectManagerApi.Data.Repository;
using Microsoft.EntityFrameworkCore;
using ProjectManagerApi.Dtos.Services;
using ProjectManagerApi.Entities;
using ProjectManagerApi.Dtos.Employees;

namespace ProjectManagerApi.Data.Repositories.Implementations
{
    public class EmployeesRepository : Repository<Employee>
    {
        public EmployeesRepository(AppDbContext db) : base(db) { }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await GetAllAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await GetAsync(id);
        }

        public async Task<bool> CreateEmployeeAsync(Employee employee)
        {
            return await CreateAsync(employee);
        }

        public async Task<bool> UpdateEmployeeAsync(Employee employee, EmployeeUpdateDto employeeUpdateDto)
        {
            employee.FirstName = employeeUpdateDto.FirstName;
            employee.LastName = employeeUpdateDto.LastName;
            employee.Patronymic = employeeUpdateDto.Patronymic;
            employee.Photo = employeeUpdateDto.Photo;
            employee.PositionId = employeeUpdateDto.PositionId;

            return await UpdateAsync(employee);
        }

        public async Task<bool> DeleteEmployeesAsync()
        {
            return await DeleteAllAsync();
        }

        public async Task<bool> DeleteEmployeeAsync(Employee employee)
        {
            return await DeleteAsync(employee);
        }
    }
}
