using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;

namespace Application.Features.NewFolder
{
    public class ProcessUploadedFile
    {
        private readonly IWebHostEnvironment webHost;

        public ProcessUploadedFile(IWebHostEnvironment webHost)
        {
            this.webHost = webHost;
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
