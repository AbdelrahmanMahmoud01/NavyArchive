using Application.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Officer.Queries.GetOfficerDetails
{
    public class GetOfficersInDepartment : IRequest<IEnumerable<Domain.Entites.Officer>>
    {
        public int Id { get; set; }

        public class GetOfficersInDepartmentHandler : IRequestHandler<GetOfficersInDepartment, IEnumerable<Domain.Entites.Officer>>
        {
            private readonly IOfficerReposiotry reposiotry;

            public GetOfficersInDepartmentHandler(IOfficerReposiotry reposiotry)
            {
                this.reposiotry = reposiotry;
            }
            public async Task<IEnumerable<Domain.Entites.Officer>> Handle(GetOfficersInDepartment request, CancellationToken cancellationToken)
            {
                return await reposiotry.GetDepartmentOfficers(request.Id);
            }
        }
    }
}
