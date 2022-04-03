using Application.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.FileInfo.Queries.GetFilesQuery
{
    public class FileInfoQuery : IRequest<IEnumerable<Domain.Entites.FileInfo>>
    {
        public class FileInfoQueryHandler : IRequestHandler<FileInfoQuery, IEnumerable<Domain.Entites.FileInfo>>
        {
            private readonly IFileRepository repository;

            public FileInfoQueryHandler(IFileRepository repository)
            {
                this.repository = repository;
            }
            public async Task<IEnumerable<Domain.Entites.FileInfo>> Handle(FileInfoQuery request, CancellationToken cancellationToken)
            {
                var files = await repository.GetFilesAsync();
                
                return files;
            }
        }
    }
}
