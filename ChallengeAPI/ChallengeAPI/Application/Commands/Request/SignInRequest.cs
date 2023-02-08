using ChallengeAPI.Application.Commands.Response;
using MediatR;

namespace ChallengeAPI.Application.Commands.Request
{
    public class SignInRequest : IRequest<SignInResponse>
    {
        public string Username { get; set; }
        public string? Password { get; set; }
    }
}
