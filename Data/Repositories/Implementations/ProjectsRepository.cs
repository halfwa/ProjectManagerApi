using Microsoft.EntityFrameworkCore;
using ProjectManagerApi.Data.Repository;
using ProjectManagerApi.Dtos.Projects;
using ProjectManagerApi.Entities;
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

        public async Task<Project> GetProjectByNameAsync(string name)
        {
            return await Set.FirstOrDefaultAsync(s => s.Name == name);
        }

        public async Task<Project> GetProjectByLinkAsync(string link)
        {
            return await Set.FirstOrDefaultAsync(s => s.Link == link);
        }

        public async Task<bool> CreateProjectAsync(Project project)
        {
            return await CreateAsync(project);
        }

        public async Task<bool> UpdateProjectAsync(Project project, ProjectUpdateDto projectUpdateDto)
        {

            project.Name = projectUpdateDto.Name;
            project.Description = projectUpdateDto.Description;
            project.Image = projectUpdateDto.Image;
            project.Link = projectUpdateDto.Link;

            return await UpdateAsync(project);
        }

        public async Task<bool> DeleteProjectsAsync()
        {
            return await DeleteAllAsync();
        }

        public async Task<bool> DeleteProjectAsync(Project project)
        {
           return await DeleteAsync(project);
        }
    }
}
