using Application.Contracts;
using Domain.Entites;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Officer.Commands.DeleteCommand
{
    public class DeletePostCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FileDestination Department { get; set; }
        public int DepartmentId { get; set; }
        public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
        {
            private readonly IOfficerReposiotry reposiotry;

            public DeletePostCommandHandler(IOfficerReposiotry reposiotry)
            {
                this.reposiotry = reposiotry;
            }
            public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
            {
                Domain.Entites.Officer deletedOfficer = await reposiotry.GetOfficerById(request.Id);

                await reposiotry.DeleteOfficerAsync(deletedOfficer);

                return Unit.Value;
            }
        }
    }
}
