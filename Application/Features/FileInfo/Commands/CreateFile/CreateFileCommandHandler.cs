using Application.Contracts;
using Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.FileInfo.Commands.CreateFile
{
    public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, int>
    {
        private readonly IFileRepository repository;
        private readonly IAsyncReposiotry<FileSource> srcRepository;
        private readonly IOfficerReposiotry officerReposiotry;
        private readonly IWebHostEnvironment webHost;

        public CreateFileCommandHandler(IFileRepository repository,
            IAsyncReposiotry<FileSource> srcRepository,
            IOfficerReposiotry officerReposiotry,
            IWebHostEnvironment webHost)
        {
            this.repository = repository;
            this.srcRepository = srcRepository;
            this.officerReposiotry = officerReposiotry;
            this.webHost = webHost;
        }

        public async Task<int> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            //ProcessUploadedFile process = new ProcessUploadedFile(webHost);

            Domain.Entites.FileInfo file = new Domain.Entites.FileInfo
            {
                AboutTag = request.createFileViewModel.AboutTag,
                Const = request.createFileViewModel.Const,
                AboutUrl = ProcessFile(request.createFileViewModel.AboutUrl),
                Note = request.createFileViewModel.Note,
                ProcedcureTage = request.createFileViewModel.ProcedcureTage,
                ProcedcureUrl = ProcessFile(request.createFileViewModel.ProcedcureUrl),
                ReminderDate = request.createFileViewModel.ReminderDate,
                //Source = await srcRepository.GetByIdAsync(request.createFileViewModel.SourceId),
                //Officer = await officerReposiotry.GetOfficerById(request.createFileViewModel.OfficerId)
            };

            CreateFileValidator validationRules = new CreateFileValidator();

            await validationRules.ValidateAsync(request.createFileViewModel);

            await repository.AddFileAsync(file);

            return file.Id;
        }

        public string ProcessFile(IList<IFormFile> model)
        {
            string uniqueFileName = null;
            if (model != null)
            {
                foreach (var item in model)
                {
                    string uploadsFolder = Path.Combine(webHost.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + item.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        item.CopyTo(fileStream);
                    }
                }

            }

            return uniqueFileName;
        }
    }
}
