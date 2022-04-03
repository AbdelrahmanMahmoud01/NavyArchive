using Application.Contracts;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Officer.GetOfficersList
{
    public class GetOfficersListCommand : IRequest<List<GetOfficersListViewModel>>
    {
        public class GetOfficersListCommandHandler : IRequestHandler<GetOfficersListCommand, List<GetOfficersListViewModel>>
        {
            private readonly IMapper mapper;
            private readonly IOfficerReposiotry reposiotry;

            public GetOfficersListCommandHandler(IMapper mapper, IOfficerReposiotry reposiotry)
            {
                this.mapper = mapper;
                this.reposiotry = reposiotry;
            }

            public async Task<List<GetOfficersListViewModel>> Handle(GetOfficersListCommand request, CancellationToken cancellationToken)
            {
                var allOfficers = await reposiotry.GetOfficersListAsync();

                return mapper.Map<List<GetOfficersListViewModel>>(allOfficers);
            }
        }
    }
}
