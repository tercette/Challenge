using AutoMapper;
using ChallengeAPI.Application.Commands.Request;
using ChallengeAPI.Application.Commands.Response;
using ChallengeAPI.Application.Models;
using ChallengeAPI.Application.Notifications;
using ChallengeAPI.Application.Repositories;
using MediatR;
using System.Diagnostics.Eventing.Reader;

namespace ChallengeAPI.Application.CommandHandlers
{
    public class AddOperationCommandHandler : IRequestHandler<AddOperationRequest, AddOperationResponse>
    {
        private readonly IMediator _mediator;
        private readonly IOperationRepository _repository;
        private readonly IMapper _mapper;

        public AddOperationCommandHandler(IMediator mediator, IOperationRepository repository, IMapper mapper)
        {
            this._mediator = mediator;
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<AddOperationResponse> Handle(AddOperationRequest request, CancellationToken cancellationToken)
        {
            if (request.TypeOperation > 1 || request.TypeOperation < 0)
                return null;

            if (request.TypeOperation.Equals(Convert.ToInt32(TypeOperation.Debit)))
                request.ValueOperation = request.ValueOperation * -1;

            await _repository.AddOperation(_mapper.Map<Operation>(request));

            var dailyResult = await _repository.GetDailyReport(DateTime.Now);
            var total = dailyResult.Sum(x => x.ValueOperation);

            return new AddOperationResponse { DailyOperations = dailyResult, DailyTotal = total };
        }
    }
}
