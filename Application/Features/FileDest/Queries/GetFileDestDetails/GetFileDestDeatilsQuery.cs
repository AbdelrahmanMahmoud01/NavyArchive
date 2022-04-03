using Application.Contracts;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.FileDest.Queries.GetFileDestDetails
{
    public class GetFileDestDeatilsQuery : IRequest<GetFileDestDetailsViewModel>
    {
        public int Id { get; set; }

        public class GetFileDestDeatilsQueryHandler : IRequestHandler<GetFileDestDeatilsQuery, GetFileDestDetailsViewModel>
        {
            private readonly IMapper mapper;
            private readonly IDepartmentRepository reposiotry;

            public GetFileDestDeatilsQueryHandler(IMapper mapper , IDepartmentRepository reposiotry)
            {
                this.mapper = mapper;
                this.reposiotry = reposiotry;
            }

            public async Task<GetFileDestDetailsViewModel> Handle(GetFileDestDeatilsQuery request, CancellationToken cancellationToken)
            {
                var destDetails = await reposiotry.GetDestinationById(request.Id);

                return mapper.Map<GetFileDestDetailsViewModel>(destDetails);
            }
        }
    }
}
