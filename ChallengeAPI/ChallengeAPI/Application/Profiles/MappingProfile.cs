using AutoMapper;
using ChallengeAPI.Application.Commands.Request;
using ChallengeAPI.Application.Commands.Response;
using ChallengeAPI.Application.Models;

namespace ChallengeAPI.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<SignInResponse, User>().ReverseMap();
            this.CreateMap<AddOperationRequest, Operation>().ReverseMap();
        }
    }
}
