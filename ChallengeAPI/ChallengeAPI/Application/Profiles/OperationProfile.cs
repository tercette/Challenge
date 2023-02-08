using AutoMapper;
using ChallengeAPI.Application.Commands.Request;
using ChallengeAPI.Application.Models;

namespace ChallengeAPI.Application.Profiles
{
    public class OperationProfile : Profile
    {
        public OperationProfile()
        {
            CreateMap<AddOperationRequest, Operation>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => $"{src.Description}"))
                .ForMember(dest => dest.ValueOperation, opt => opt.MapFrom(src => $"{src.ValueOperation}"))
                .ForMember(dest => dest.TypeOperation, opt => opt.MapFrom(src => $"{src.TypeOperation}"));
        }
    }
}
