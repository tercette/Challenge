using ChallengeAPI.Application.Models;

namespace ChallengeAPI.Application.Repositories
{
    public interface IUserRepository
    {
        Task<User> Get(string username, string password);
    }
}
