using Application.Contracts;
using Domain.Entites;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.FileDest.Commands.DeleteFileDest
{
    public class DeleteFileDestCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteFileDestCommandHandler : IRequestHandler<DeleteFileDestCommand>
        {
            private readonly IAsyncReposiotry<FileDestination> reposiotry;

            public DeleteFileDestCommandHandler(IAsyncReposiotry<FileDestination> reposiotry)
            {
                this.reposiotry = reposiotry;
            }
            public async Task<Unit> Handle(DeleteFileDestCommand request, CancellationToken cancellationToken)
            {
                var deletedFileDest = await reposiotry.GetByIdAsync(request.Id);

                await reposiotry.DeleteAsync(deletedFileDest);
                return Unit.Value;
            }
        }
    }
}
