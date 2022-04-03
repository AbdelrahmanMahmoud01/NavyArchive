using Application.Contracts;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly DataContext context;

        public FileRepository(DataContext context)
        {
            this.context = context;
        }
        public async Task<FileInfo> AddAsync(FileInfo entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<FileInfo> AddFileAsync(FileInfo entity)
        {
            await context.FilesInfo.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<FileInfo> GetByIdAsync(int id)
        {
            FileInfo dtos = await context.FilesInfo.AsNoTracking()
                //.Include(x=>x.Source)
                //.Include(x=> x.Destinations)
                //.ThenInclude(x => x.Officers)
                .FirstOrDefaultAsync(x => x.Id == id);

            return dtos;
        }

        public async Task<IEnumerable<FileInfo>> GetFilesAsync()
        {
            List<FileInfo> allFiles = await context.FilesInfo
                //.Include(x => x.Source)
                //.Include(x => x.Destinations)
                //.ThenInclude(x => x.Officers)
                .AsNoTracking()
                .ToListAsync();

            return allFiles;
        }
    }
}
