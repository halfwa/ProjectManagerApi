using AutoMapper;
using ProjectManagerApi.Dtos.Employees;
using ProjectManagerApi.Dtos.Projects;
using ProjectManagerApi.Entities;
using ProjectManagerApi.Models.Employees;

namespace ProjectManagerApi.Profiles
{
    public class EmployeeProfile: Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<Employee, EmployeeReadDto>();
            CreateMap<EmployeeUpdateDto, Employee>();
        }
    }
}
