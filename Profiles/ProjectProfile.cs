using AutoMapper;
using ProjectManagerApi.Dtos.Projects;
using ProjectManagerApi.Entities;

namespace ProjectManagerApi.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectCreateDto, Project>();
            CreateMap<Project, ProjectReadDto>();
            CreateMap<ProjectUpdateDto, Project>();
        }
    }
}
