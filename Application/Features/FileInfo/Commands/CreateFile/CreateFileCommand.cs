using Application.Features.FileInfo.Commands.CreateFileCommand;
using MediatR;

namespace Application.Features.FileInfo.Commands.CreateFile
{
    public class CreateFileCommand : IRequest<int>
    {
        public CreateFileViewModel createFileViewModel { get; set; }

        
    }
}
