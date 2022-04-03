using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ModelConfigurations
{
    public class SourceEntityTypeConfiguration : IEntityTypeConfiguration<FileSource>
    {
        public void Configure(EntityTypeBuilder<FileSource> builder)
        {
            builder
                .Property(s => s.Name).IsRequired()
                .HasMaxLength(25)
                .HasColumnName("الأسم");
        }
    }
}
