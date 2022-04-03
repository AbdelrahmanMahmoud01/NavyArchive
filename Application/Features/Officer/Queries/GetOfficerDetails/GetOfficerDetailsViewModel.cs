using Domain.Entites;

namespace Application.Features.Officer.GetOfficerDetails
{
    public class GetOfficerDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FileDestination Destination { get; set; }
    }
}
