using AutoMapper;
using ChallengeAPI.Application.Commands.Request;
using ChallengeAPI.Application.Commands.Response;
using ChallengeAPI.Application.Models;
using ChallengeAPI.Application.Notifications;
using ChallengeAPI.Application.Services;
using ChallengeAPI.Application.Repositories;
using MediatR;

namespace ChallengeAPI.Application.CommandHandlers
{
    public class SignInRequestHandler : IRequestHandler<SignInRequest, SignInResponse>
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public SignInRequestHandler(IMediator mediator, IUserRepository repository, IMapper mapper)
        {
            this._mediator = mediator;
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task<SignInResponse> Handle(SignInRequest request, CancellationToken cancellationToken)
        {
            var response = _mapper.Map<SignInResponse>(await _repository.Get(request.Username, request.Password));
            if (response is null)
                await _mediator.Publish(new SignInNotification { Username = request.Username, Message = "Username or Password is incorrect!" });
            else
            {
                await _mediator.Publish(new SignInNotification { Username = response.Username, Message = "Signin Success" });
                response.Token = TokenService.Generate(response.Username);
            }

            return await Task.FromResult(response);
        }
    }
}
