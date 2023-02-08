using ChallengeAPI.Application.Mappings;
using ChallengeAPI.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeAPI.Application.Repositories
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Operation> Operations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new OperationMap());
        }
    }
}
