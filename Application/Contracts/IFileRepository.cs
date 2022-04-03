using Domain.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IFileRepository
    {
        Task<IEnumerable<FileInfo>> GetFilesAsync();
        Task<FileInfo> AddFileAsync(FileInfo fileInfo);
    }
}
