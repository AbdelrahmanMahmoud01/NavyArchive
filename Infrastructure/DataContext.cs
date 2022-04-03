using Domain.Entites;
using Infrastructure.ModelConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public virtual DbSet<FileSource> Sources { get; set; }
        public virtual DbSet<FileDestination> Destinations { get; set; }
        public virtual DbSet<FileInfo> FilesInfo { get; set; }
        public virtual DbSet<Officer> Officers { get; set; }
        public virtual DbSet<FileInfoSoruce> FileInfoSoruce { get; set; }
        public virtual DbSet<FileInfoOfficers> FileInfoOfficers { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new DepartmentEntityTypeConfiguration().Configure(builder.Entity<FileDestination>());
            new SourceEntityTypeConfiguration().Configure(builder.Entity<FileSource>());
            new OfficerEntityTypeConfiguration().Configure(builder.Entity<Officer>());
            new FileEntityTypeConfiguration().Configure(builder.Entity<FileInfo>());

            builder.Entity<FileInfoSoruce>().HasKey(ES => new { ES.FileInfoId, ES.FileSourceId });
            builder.Entity<FileInfoOfficers>().HasKey(ES => new { ES.FileInfoId, ES.OfficerId });



        }
    }
}
