using Application.Contracts;
using Domain.Entites;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Officer.Commands.UpdateCommand
{
    public class UpdateOfficerPostCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<FileDestination> Department { get; set; }
        public int DepartmentId { get; set; }


        public class UpdateOfficerPostCommandHandler : IRequestHandler<UpdateOfficerPostCommand,int>
        {
            private readonly IDepartmentRepository departmentRepository;
            private readonly IOfficerReposiotry reposiotry;

            public UpdateOfficerPostCommandHandler(IDepartmentRepository departmentRepository, IOfficerReposiotry reposiotry)
            {
                this.departmentRepository = departmentRepository;
                this.reposiotry = reposiotry;
            }
            public async Task<int> Handle(UpdateOfficerPostCommand request, CancellationToken cancellationToken)
            {
                Domain.Entites.Officer officer = new Domain.Entites.Officer
                {
                    Id = request.Id,
                    Name = request.Name,
                    Destination = await departmentRepository.GetByIdAsync(request.DepartmentId),
                };

                UpdateOfficerValidation validations = new UpdateOfficerValidation();
                await validations.ValidateAsync(request);

                var query = await reposiotry.UpdateOfficerAsync(officer);

                return query;
            }
        }
    }
}
