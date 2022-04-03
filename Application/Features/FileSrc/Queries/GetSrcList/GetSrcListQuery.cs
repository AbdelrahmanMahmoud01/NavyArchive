using Application.Contracts;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.FileSrc.Queries.GetSrcList
{
    public class GetSrcListQuery : IRequest<List<GetSrcListViewModel>>
    {
        public class GetSrcListHandler : IRequestHandler<GetSrcListQuery, List<GetSrcListViewModel>>
        {
            private readonly IAsyncReposiotry<FileSource> reposiotry;
            private readonly IMapper mapper;

            public GetSrcListHandler(IAsyncReposiotry<FileSource> reposiotry , IMapper mapper)
            {
                this.reposiotry = reposiotry;
                this.mapper = mapper;
            }
            public async Task<List<GetSrcListViewModel>> Handle(GetSrcListQuery request, CancellationToken cancellationToken)
            {
                var allSrcs = await reposiotry.ListAllAsync();
                return mapper.Map<List<GetSrcListViewModel>>(allSrcs);
            }
        }
    }
}
