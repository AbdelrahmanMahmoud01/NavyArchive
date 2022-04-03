using Application.Contracts;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.FileDest.Commands.UpdateFileDest
{
    public class UpdateFileDestGet : IRequest<UpdateFileDestCommand>
    {
        public int Id { get; set; }

        public class UpateFileDestGetHanlder : IRequestHandler<UpdateFileDestGet, UpdateFileDestCommand>
        {
            private readonly IAsyncReposiotry<FileDestination> reposiotry;
            private readonly IMapper mapper;

            public UpateFileDestGetHanlder(IAsyncReposiotry<FileDestination> reposiotry,IMapper mapper)
            {
                this.reposiotry = reposiotry;
                this.mapper = mapper;
            }
            public async Task<UpdateFileDestCommand> Handle(UpdateFileDestGet request, CancellationToken cancellationToken)
            {
                var destDetails = await reposiotry.GetByIdAsync(request.Id);

                return mapper.Map<UpdateFileDestCommand>(destDetails);
            }
        }
    }
}
