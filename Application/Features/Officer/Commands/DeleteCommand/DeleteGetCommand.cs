using Application.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Officer.Commands.DeleteCommand
{
    public class DeleteGetCommand : IRequest<DeletePostCommand>
    {
        public int Id { get; set; }
        public class DeleteGetCommandHandler : IRequestHandler<DeleteGetCommand, DeletePostCommand>
        {
            private readonly IOfficerReposiotry reposiotry;

            public DeleteGetCommandHandler(IOfficerReposiotry reposiotry)
            {
                this.reposiotry = reposiotry;
            }
            public async Task<DeletePostCommand> Handle(DeleteGetCommand request, CancellationToken cancellationToken)
            {
                var officer = await reposiotry.GetOfficerById(request.Id);
                DeletePostCommand command = new DeletePostCommand
                {
                    Id = officer.Id,
                    Name = officer.Name,
                    DepartmentId = officer.DestinationId,
                    Department = officer.Destination
                };

                return command;
            }
        }
    }
}
