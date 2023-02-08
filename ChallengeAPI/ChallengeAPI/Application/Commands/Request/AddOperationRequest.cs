using ChallengeAPI.Application.Commands.Response;
using MediatR;

namespace ChallengeAPI.Application.Commands.Request
{
    public class AddOperationRequest : IRequest<AddOperationResponse>
    {
        public string? Description { get; set; }
        public double ValueOperation { get; set; }
        public int TypeOperation { get; set; }
    }
}
