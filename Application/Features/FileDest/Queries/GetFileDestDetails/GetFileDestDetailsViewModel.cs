using Domain.Entites;
using System.Collections.Generic;

namespace Application.Features.FileDest.Queries.GetFileDestDetails
{
    public class GetFileDestDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Domain.Entites.Officer> Officers { get; set; }
    }
}
