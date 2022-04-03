using Application.Contracts;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.FileDest.Commands.CreateFileDest
{
    public class CreateFileDestCommand : IRequest<int>
    {
        public string Name { get; set; }

        public class CreateFileDestCommandHandler : IRequestHandler<CreateFileDestCommand, int>
        {
            private readonly IAsyncReposiotry<FileDestination> reposiotry;
            private readonly IMapper mapper;

            public CreateFileDestCommandHandler(IAsyncReposiotry<FileDestination> reposiotry, IMapper mapper)
            {
                this.reposiotry = reposiotry;
                this.mapper = mapper;
            }



            public async Task<int> Handle(CreateFileDestCommand request, CancellationToken cancellationToken)
            {
                var fileDestination = mapper.Map<FileDestination>(request);

                CreateFileDestValidator validationRules = new CreateFileDestValidator();
                var result = await validationRules.ValidateAsync(request);

                fileDestination = await reposiotry.AddAsync(fileDestination);

                return fileDestination.Id;
            }
        }
    }
}
