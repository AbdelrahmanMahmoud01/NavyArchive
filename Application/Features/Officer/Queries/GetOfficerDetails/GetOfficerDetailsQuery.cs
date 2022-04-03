using Application.Contracts;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Officer.GetOfficerDetails
{
    public class GetOfficerDetailsQuery : IRequest<GetOfficerDetailsViewModel>
    {
        public int Id { get; set; }

        public class GetOfficerDetailsQueryHandler : IRequestHandler<GetOfficerDetailsQuery, GetOfficerDetailsViewModel>
        {
            private readonly IOfficerReposiotry reposiotry;
            private readonly IMapper mapper;

            public GetOfficerDetailsQueryHandler(IOfficerReposiotry reposiotry , IMapper mapper)
            {
                this.reposiotry = reposiotry;
                this.mapper = mapper;
            }

            public async Task<GetOfficerDetailsViewModel> Handle(GetOfficerDetailsQuery request, CancellationToken cancellationToken)
            {
                var officerDetails = await reposiotry.GetOfficerById(request.Id);
                return mapper.Map<GetOfficerDetailsViewModel>(officerDetails);
            }
        }
    }
}
