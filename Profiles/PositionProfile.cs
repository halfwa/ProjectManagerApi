using AutoMapper;
using ProjectManagerApi.Dtos.Employees;
using ProjectManagerApi.Dtos.Employees.Positions;
using ProjectManagerApi.Models.Employees;

namespace ProjectManagerApi.Profiles
{
    public class PositionProfile: Profile
    {
        public PositionProfile()
        {
            CreateMap<PositionCreateDto, Position>();
            CreateMap<Position, PositionReadDto>();
            CreateMap<PositionUpdateDto, Position>();
        }
    }
}
