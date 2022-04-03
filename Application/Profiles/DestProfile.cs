using Application.Features.FileDest.Commands.CreateFileDest;
using Application.Features.FileDest.Commands.DeleteFileDest;
using Application.Features.FileDest.Commands.UpdateFileDest;
using Application.Features.FileDest.Queries;
using Application.Features.FileDest.Queries.GetFileDestDetails;
using AutoMapper;
using Domain.Entites;

namespace Application.Profiles
{
    public class DestProfile : Profile
    {
        public DestProfile()
        {
            CreateMap<FileDestination,GetFileDestViewModel>().ReverseMap();
            CreateMap<FileDestination, GetFileDestDetailsViewModel>().ReverseMap();
            CreateMap<FileDestination, CreateFileDestCommand>().ReverseMap();
            CreateMap<FileDestination, UpdateFileDestCommand>().ReverseMap();
            CreateMap<FileDestination, DeleteFileDestCommand>().ReverseMap();
            CreateMap<UpdateFileDestCommand, UpdateFileDestGet>().ReverseMap();
        }
    }
}
