using ChallengeAPI.Application.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ChallengeAPI.Application.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User))
                .HasKey(p => p.Id);
            builder.Property(p => p.Username).HasMaxLength(20);
            builder.Property(p => p.Password).HasMaxLength(50);
        }
    }
}
