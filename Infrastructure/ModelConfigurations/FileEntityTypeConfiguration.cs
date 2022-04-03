using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ModelConfigurations
{
    public class FileEntityTypeConfiguration : IEntityTypeConfiguration<FileInfo>
    {
        public void Configure(EntityTypeBuilder<FileInfo> builder)
        {
            builder
                .Property(f => f.AboutTag).IsRequired();

            builder
                .Property(f => f.Const).IsRequired()
                .HasMaxLength(100);

            builder
                .Property(f => f.ProcedcureTage);

            builder
                .Property(f => f.OfficerId).IsRequired();

            builder
                .Property(f => f.SourceId).IsRequired();

            builder
                .Property(f => f.ReminderDate).IsRequired();
        }
    }
}
