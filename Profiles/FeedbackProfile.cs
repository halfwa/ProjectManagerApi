using AutoMapper;
using ProjectManagerApi.Dtos;
using ProjectManagerApi.Entities;

namespace ProjectManagerApi.Profiles
{
    public class FeedbackProfile: Profile
    {
        public FeedbackProfile()
        {
            CreateMap<FeedbackCreateDto, Feedback>();
        }
    }
}
