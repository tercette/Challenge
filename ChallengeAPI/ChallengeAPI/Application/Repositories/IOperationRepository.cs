using ChallengeAPI.Application.Models;

namespace ChallengeAPI.Application.Repositories
{
    public interface IOperationRepository
    {
        Task AddOperation(Operation request);
        Task<List<Operation>> GetDailyReport(DateTime date);
    }
}
