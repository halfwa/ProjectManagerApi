using AutoMapper;
using ProjectManagerApi.Dtos.Projects;
using ProjectManagerApi.Dtos.Services;
using ProjectManagerApi.Entities;

namespace ProjectManagerApi.Profiles
{
    public class ServiceProfile: Profile
    {
        public ServiceProfile()
        {
            CreateMap<ServiceCreateDto, Service>();
            CreateMap<Service, ServiceReadDto>();
            CreateMap<ServiceUpdateDto, Service>();
        }
    }
}
