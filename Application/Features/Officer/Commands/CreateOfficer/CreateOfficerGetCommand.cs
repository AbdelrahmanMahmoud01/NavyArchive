using Application.Contracts;
using Domain.Entites;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Officer.Commands.CreateOfficer
{
    public class CreateOfficerGetCommand : IRequest<CreateOfficerPostCommand>
    {
        public class CreateOfficerGetCommandHandelr : IRequestHandler<CreateOfficerGetCommand, CreateOfficerPostCommand>
        {
            private readonly IAsyncReposiotry<FileDestination> destRepo;

            public CreateOfficerGetCommandHandelr(IAsyncReposiotry<FileDestination> destRepo)
            {
                this.destRepo = destRepo;
            }
            public async Task<CreateOfficerPostCommand> Handle(CreateOfficerGetCommand request, CancellationToken cancellationToken)
            {

                var allOfficerDepartments = await destRepo.ListAllAsync();
                var model = new CreateOfficerPostCommand
                {
                    Department = allOfficerDepartments
                };

                return model;

            }
        }
    }
}
