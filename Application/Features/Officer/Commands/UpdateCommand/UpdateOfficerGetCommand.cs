using Application.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Officer.Commands.UpdateCommand
{
    public class UpdateOfficerGetCommand : IRequest<UpdateOfficerPostCommand>
    {
        public int Id { get; set; }

        public class UpdateOfficerGetCommandHandler : IRequestHandler<UpdateOfficerGetCommand, UpdateOfficerPostCommand>
        {
            private readonly IOfficerReposiotry reposiotry;
            private readonly IDepartmentRepository departmentRepository;

            public UpdateOfficerGetCommandHandler(IOfficerReposiotry reposiotry,IDepartmentRepository departmentRepository)
            {
                this.reposiotry = reposiotry;
                this.departmentRepository = departmentRepository;
            }

            public async Task<UpdateOfficerPostCommand> Handle(UpdateOfficerGetCommand request, CancellationToken cancellationToken)
            {
                var officer = await reposiotry.GetOfficerById(request.Id);
                UpdateOfficerPostCommand command = new UpdateOfficerPostCommand();
                if (officer is null)
                    return command;

                else
                {
                    command.Id = officer.Id;
                    command.Name = officer.Name;
                    command.Department = await departmentRepository.ListAllAsync();
                    command.DepartmentId = officer.DestinationId;

                    return command;
                }
            }
        }
    }
}
