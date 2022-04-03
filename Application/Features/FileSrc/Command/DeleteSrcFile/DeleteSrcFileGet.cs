using Application.Contracts;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.FileSrc.Command.DeleteSrcFile
{
    public class DeleteSrcFileGet : IRequest<FileSource>
    {
        public int Id { get; set; }

        public class DeleteSrcFileGetHanlder : IRequestHandler<DeleteSrcFileGet, FileSource>
        {
            private readonly IAsyncReposiotry<FileSource> reposiotry;
            private readonly IMapper mapper;

            public DeleteSrcFileGetHanlder(IAsyncReposiotry<FileSource> reposiotry , IMapper mapper)
            {
                this.reposiotry = reposiotry;
                this.mapper = mapper;
            }
            public async Task<FileSource> Handle(DeleteSrcFileGet request, CancellationToken cancellationToken)
            {
                var destDeleteDetails = await reposiotry.GetByIdAsync(request.Id);

                return mapper.Map<FileSource>(destDeleteDetails);
            }
        }
    }
}
