using Application.Contracts;
using Domain.Entites;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.FileSrc.Command.DeleteSrcFile
{
    public class DeleteSrcFileCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteSrcFileCommandHandler : IRequestHandler<DeleteSrcFileCommand>
        {
            private readonly IAsyncReposiotry<FileSource> reposiotry;

            public DeleteSrcFileCommandHandler(IAsyncReposiotry<FileSource> reposiotry)
            {
                this.reposiotry = reposiotry;
            }

            public async Task<Unit> Handle(DeleteSrcFileCommand request, CancellationToken cancellationToken)
            {
                var deletedSrcFile = await reposiotry.GetByIdAsync(request.Id);

                await reposiotry.DeleteAsync(deletedSrcFile);
                return Unit.Value;
            }
        }
    }
}
