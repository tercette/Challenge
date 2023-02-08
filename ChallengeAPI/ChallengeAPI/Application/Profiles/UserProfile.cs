using AutoMapper;
using ChallengeAPI.Application.Commands.Response;
using ChallengeAPI.Application.Models;

namespace ChallengeAPI.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<SignInResponse, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => $"{src.Id}"))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => $"{src.Username}"));
        }
    }
}
