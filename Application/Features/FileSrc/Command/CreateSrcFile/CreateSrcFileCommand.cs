using Application.Contracts;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.FileSrc.Command.CreateSrcFile
{
    public class CreateSrcFileCommand : IRequest<int>
    {
        public string Name { get; set; }

        public class CreateSrcFileHandler : IRequestHandler<CreateSrcFileCommand, int>
        {
            private readonly IAsyncReposiotry<FileSource> reposiotry;
            private readonly IMapper mapper;

            public CreateSrcFileHandler(IAsyncReposiotry<FileSource> reposiotry, IMapper mapper)
            {
                this.reposiotry = reposiotry;
                this.mapper = mapper;
            }

            public async Task<int> Handle(CreateSrcFileCommand request, CancellationToken cancellationToken)
            {
                var fileSrc = mapper.Map<FileSource>(request);

                CreateSrcFileValidator validationRules = new CreateSrcFileValidator();

                await validationRules.ValidateAsync(request);

                fileSrc = await reposiotry.AddAsync(fileSrc);

                return fileSrc.Id;
            }
        }
    }
}
