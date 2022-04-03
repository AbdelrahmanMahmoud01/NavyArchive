using Application.Contracts;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.FileSrc.Command.UpdateSrcFile
{
    public class UpdateSrcFileCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public class UpdateSrcFileCommandHandler : IRequestHandler<UpdateSrcFileCommand, int>
        {
            private readonly IAsyncReposiotry<FileSource> reposiotry;
            private readonly IMapper mapper;

            public UpdateSrcFileCommandHandler(IAsyncReposiotry<FileSource> reposiotry , IMapper mapper)
            {
                this.reposiotry = reposiotry;
                this.mapper = mapper;
            }
            public async Task<int> Handle(UpdateSrcFileCommand request, CancellationToken cancellationToken)
            {
                var srcUpdated = mapper.Map<FileSource>(request);

                UpdateSrcFileValidator validationRules = new UpdateSrcFileValidator();

                await validationRules.ValidateAsync(request);

                srcUpdated =  await reposiotry.UpdateAsync(srcUpdated);

                return srcUpdated.Id;
            }
        }
    }
}
