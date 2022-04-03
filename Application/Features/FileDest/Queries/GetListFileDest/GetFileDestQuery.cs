using Application.Contracts;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.FileDest.Queries
{
    public class GetFileDestQuery : IRequest<List<GetFileDestViewModel>>
    {
        public class GetFileDestQueryHandler : IRequestHandler<GetFileDestQuery, List<GetFileDestViewModel>>
        {
            private readonly IAsyncReposiotry<FileDestination> reposiotry;
            private readonly IMapper mapper;

            public GetFileDestQueryHandler(IAsyncReposiotry<FileDestination> reposiotry, IMapper mapper)
            {
                this.reposiotry = reposiotry;
                this.mapper = mapper;
            }

            public async Task<List<GetFileDestViewModel>> Handle(GetFileDestQuery request, CancellationToken cancellationToken)
            {
                var allDestinations = await reposiotry.ListAllAsync();

                return mapper.Map<List<GetFileDestViewModel>>(allDestinations);
            }
        }
    }
}
