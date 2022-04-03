using Application.Contracts;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.FileDest.Commands.UpdateFileDest
{
    public class UpdateFileDestCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateFileDestCommandHandler : IRequestHandler<UpdateFileDestCommand, int>
        {
            public UpdateFileDestCommandHandler(IMapper mapper , IAsyncReposiotry<FileDestination> reposiotry)
            {
                Mapper = mapper;
                Reposiotry = reposiotry;
            }

            public IMapper Mapper { get; }
            public IAsyncReposiotry<FileDestination> Reposiotry { get; }

            public async Task<int> Handle(UpdateFileDestCommand request, CancellationToken cancellationToken)
            {
                var destUpdated = Mapper.Map<FileDestination>(request);

                var query = await Reposiotry.UpdateAsync(destUpdated);

                return query.Id;
            }
        }
    }
}
