using Application.Features.FileSrc.Command.CreateSrcFile;
using Application.Features.FileSrc.Command.DeleteSrcFile;
using Application.Features.FileSrc.Command.UpdateSrcFile;
using Application.Features.FileSrc.Queries.GetSrcDetails;
using Application.Features.FileSrc.Queries.GetSrcList;
using AutoMapper;
using Domain.Entites;

namespace Application.Profiles
{
    public class SrcProfile : Profile
    {
        public SrcProfile()
        {
            CreateMap<FileSource, GetSrcListViewModel>().ReverseMap();
            CreateMap<FileSource, GetSrcDetailsViewModel>().ReverseMap();
            CreateMap<FileSource, CreateSrcFileCommand>().ReverseMap();
            CreateMap<FileSource, UpdateSrcFileCommand>().ReverseMap();
            CreateMap<FileSource, DeleteSrcFileCommand>().ReverseMap();
            CreateMap<UpdateSrcFileCommand, UpdateSrcFileGet>().ReverseMap();

        }
    }
}
