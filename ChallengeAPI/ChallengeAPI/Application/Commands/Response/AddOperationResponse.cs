using ChallengeAPI.Application.Models;

namespace ChallengeAPI.Application.Commands.Response
{
    public class AddOperationResponse
    {
        public List<Operation> DailyOperations { get; set; }
        public double DailyTotal { get; set; }
    }
}
