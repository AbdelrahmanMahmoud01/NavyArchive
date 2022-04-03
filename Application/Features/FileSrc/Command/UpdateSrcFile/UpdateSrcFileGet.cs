using Application.Contracts;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.FileSrc.Command.UpdateSrcFile
{
    public class UpdateSrcFileGet : IRequest<UpdateSrcFileCommand>
    {
        public int Id { get; set; }

        public class UpdateSrcFileGetHandler : IRequestHandler<UpdateSrcFileGet, UpdateSrcFileCommand>
        {
            private readonly IMapper mapper;
            private readonly IAsyncReposiotry<FileSource> reposiotry;

            public UpdateSrcFileGetHandler(IMapper mapper , IAsyncReposiotry<FileSource> reposiotry)
            {
                this.mapper = mapper;
                this.reposiotry = reposiotry;
            }

            public async Task<UpdateSrcFileCommand> Handle(UpdateSrcFileGet request, CancellationToken cancellationToken)
            {
                var destDetails = await reposiotry.GetByIdAsync(request.Id);

                return mapper.Map<UpdateSrcFileCommand>(destDetails);
            }
        }
    }
}
