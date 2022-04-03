using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ModelConfigurations
{
    public class DepartmentEntityTypeConfiguration : IEntityTypeConfiguration<FileDestination>
    {
        public void Configure(EntityTypeBuilder<FileDestination> builder)
        {
            builder
                .Property(s => s.Name).IsRequired()
                .HasMaxLength(25)
                .HasColumnName("الأسم"); 
        }
    }
}
