using AutoMapper;
using ProjectManagerApi.Dtos.Projects;
using ProjectManagerApi.Models.Projects;

namespace ProjectManagerApi.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectCreateDto, Project>();
            CreateMap<Project, ProjectReadDto>();
        }
    }
}
