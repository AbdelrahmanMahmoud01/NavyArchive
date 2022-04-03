using Application.Contracts;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.FileSrc.Queries.GetSrcDetails
{
    public class GetSrcDetailsQuery : IRequest<GetSrcDetailsViewModel>
    {
        public int Id { get; set; }

        public class GetSrcDetailsHandler : IRequestHandler<GetSrcDetailsQuery, GetSrcDetailsViewModel>
        {
            private readonly IAsyncReposiotry<FileSource> reposiotry;
            private readonly IMapper mapper;

            public GetSrcDetailsHandler(IAsyncReposiotry<FileSource> reposiotry , IMapper mapper)
            {
                this.reposiotry = reposiotry;
                this.mapper = mapper;
            }

            public async Task<GetSrcDetailsViewModel> Handle(GetSrcDetailsQuery request, CancellationToken cancellationToken)
            {
                var srcDetails = await reposiotry.GetByIdAsync(request.Id);
                return mapper.Map<GetSrcDetailsViewModel>(srcDetails);
            }
        }
    }
}
