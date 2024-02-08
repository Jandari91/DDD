using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Specification.Core.Domain.Entity;

namespace Specification.Infrastructure.Persistence.EntityConfiguration;

public class CircleEntityConfiguration : IEntityTypeConfiguration<Circle>
{
    public void Configure(EntityTypeBuilder<Circle> builder)
    {
        builder.HasKey(e => e.Id);
    }
}