using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ChallengeAPI.Application.Models;

namespace ChallengeAPI.Application.Mappings
{
    public class OperationMap : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.ToTable(nameof(Operation))
                    .HasKey(p => p.Id);

            builder.Property(p => p.Description).HasMaxLength(100);
            builder.Property(p => p.ValueOperation).IsRequired();
            builder.Property(p => p.Date).IsRequired();
            builder.Property(p => p.TypeOperation).IsRequired();
        }
    }
}
