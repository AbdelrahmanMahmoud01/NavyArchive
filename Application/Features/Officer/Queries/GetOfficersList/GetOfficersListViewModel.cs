using Domain.Entites;

namespace Application.Features.Officer.GetOfficersList
{
    public class GetOfficersListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FileDestination Destination { get; set; }
    }
}
