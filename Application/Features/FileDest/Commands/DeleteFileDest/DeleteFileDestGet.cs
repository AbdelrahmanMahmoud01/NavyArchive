using Application.Contracts;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.FileDest.Commands.DeleteFileDest
{
    public class DeleteFileDestGet : IRequest<FileDestination>
    {
        public int Id { get; set; }

        public class DeleteFileDestGetHandler : IRequestHandler<DeleteFileDestGet, FileDestination>
        {
            private readonly IAsyncReposiotry<FileDestination> reposiotry;
            private readonly IMapper mapper;

            public DeleteFileDestGetHandler(IAsyncReposiotry<FileDestination> reposiotry , IMapper mapper)
            {
                this.reposiotry = reposiotry;
                this.mapper = mapper;
            }
            public async Task<FileDestination> Handle(DeleteFileDestGet request, CancellationToken cancellationToken)
            {
                var destDetails = await reposiotry.GetByIdAsync(request.Id);

                return mapper.Map<FileDestination>(destDetails);
            }
        }
    }
}
