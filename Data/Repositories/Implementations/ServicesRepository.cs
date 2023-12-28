using Microsoft.EntityFrameworkCore;
using ProjectManagerApi.Data.Repository;
using ProjectManagerApi.Dtos.Projects;
using ProjectManagerApi.Dtos.Services;
using ProjectManagerApi.Entities;

namespace ProjectManagerApi.Data.Repositories.Implementations
{
    public class ServicesRepository : Repository<Service>
    {
        public ServicesRepository(AppDbContext db) : base(db) { }

        public async Task<IEnumerable<Service>> GetServicesAsync()
        {
            return await GetAllAsync();
        }
        public async Task<Service> GetServiceByIdAsync(int id)
        {
            return await GetAsync(id);
        }
        public async Task<Service> GetServiceByNameAsync(string name)
        {
            return await Set.FirstOrDefaultAsync(s => s.Name == name);
        }

        public async Task<bool> CreateServiceAsync(Service service)
        {
            return await CreateAsync(service);
        }

        public async Task<bool> UpdateServiceAsync(Service service, ServiceUpdateDto serviceUpdateDto)
        {
            service.Name = serviceUpdateDto.Name;
            service.Description = serviceUpdateDto.Description;
            service.Image = serviceUpdateDto.Image;

            return await UpdateAsync(service);
        }

        public async Task<bool> DeleteServicesAsync()
        {
            return await DeleteAllAsync();
        }
        public async Task<bool> DeleteServiceAsync(Service service)
        {
            return await DeleteAsync(service);
        }
    }
}
