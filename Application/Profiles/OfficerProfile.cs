using Application.Features.Officer.Commands.CreateOfficer;
using Application.Features.Officer.GetOfficerDetails;
using Application.Features.Officer.GetOfficersList;
using Application.Features.Officer.Queries.GetOfficersList;
using AutoMapper;
using Domain.Entites;

namespace Application.Profiles
{
    public class OfficerProfile : Profile
    {
        public OfficerProfile()
        {
            CreateMap<Officer, GetOfficersListViewModel>().ReverseMap();
            CreateMap<Officer, GetOfficerDetailsViewModel>().ReverseMap();
            CreateMap<FileDestination, DestinationDTO>().ReverseMap();
            CreateMap<FileDestination, CreateOfficerFileDepartmentDTO>().ReverseMap();
            CreateMap<Officer, CreateOfficerPostCommand>().ReverseMap();
        }
    }
}
