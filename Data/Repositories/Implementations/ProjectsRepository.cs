using Microsoft.EntityFrameworkCore;
using ProjectManagerApi.Data.Repository;
using ProjectManagerApi.Dtos.Projects;
using ProjectManagerApi.Models.Projects;
using System.Collections;


namespace ProjectManagerApi.Data.Repositories.Implementations
{
    public class ProjectsRepository : Repository<Project>
    {
        public ProjectsRepository(AppDbContext db) : base(db) { }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await GetAllAsync();
        }
        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await GetAsync(id);
        }

        public async Task CreateProjectAsync(Project project)
        {
            await CreateAsync(project);
        }
    }
}
