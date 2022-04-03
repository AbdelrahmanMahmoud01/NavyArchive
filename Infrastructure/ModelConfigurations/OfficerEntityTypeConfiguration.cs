using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ModelConfigurations
{
    public class OfficerEntityTypeConfiguration : IEntityTypeConfiguration<Officer>
    {
        public void Configure(EntityTypeBuilder<Officer> builder)
        {
            builder
                .Property(x => x.Name).IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.DestinationId).IsRequired();
        }
    }
}
