using Application.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using Domain.Entites;

namespace Application.Features.Officer.Commands.CreateOfficer
{
    public class CreateOfficerPostCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public IEnumerable<FileDestination> Department { get; set; }

        public class CreateofficerPostCommandHandler : IRequestHandler<CreateOfficerPostCommand, int>
        {
            private readonly IOfficerReposiotry reposiotry;
            private readonly IAsyncReposiotry<FileDestination> destRepo;

            public CreateofficerPostCommandHandler(IOfficerReposiotry reposiotry , IMapper mapper
                ,IAsyncReposiotry<FileDestination> destRepo)
            {
                this.reposiotry = reposiotry;
                this.destRepo = destRepo;
            }
            public async Task<int> Handle(CreateOfficerPostCommand request, CancellationToken cancellationToken)
            {
                Domain.Entites.Officer officer = new Domain.Entites.Officer
                {
                    Name = request.Name,
                    Destination = await destRepo.GetByIdAsync(request.DepartmentId)
                };

                CreateOfficerValidator validationRules = new CreateOfficerValidator();

                await validationRules.ValidateAsync(request);

                await reposiotry.AddOfficerAsync(officer);

                return officer.Id;
            }
        }
    }
}
