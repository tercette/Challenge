using ChallengeAPI.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeAPI.Application.Repositories
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbInitializer(IServiceScopeFactory scopeFactory, Context context)
        {
            _scopeFactory = scopeFactory;
        }

        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<Context>())
                {
                    context.Database.EnsureCreated();

                    if (!context.Users.ToList().Any())
                    {
                        context.Add(new User { Id = Guid.NewGuid(), Username = "admin", Password = "admin" });
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
