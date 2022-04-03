//using Application.Validations;
using Domain.Entites;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Application.Features.FileInfo.Commands.CreateFileCommand
{
    public class CreateFileViewModel
    {
        public int Id { get; set; }
        public string Const { get; set; }
        public int SourceId { get; set; }
        public virtual IEnumerable<FileSource> Source { get; set; }

        //[AllowedExtensions(new string[] { ".jpg", ".png", ".pdf" })]
        public List<IFormFile> AboutUrl { get; set; }
        public string AboutTag { get; set; }
        public int DepartmentId { get; set; }
        public virtual IEnumerable<FileDestination> Department { get; set; }
        public int OfficerId { get; set; }
        public virtual IEnumerable<Domain.Entites.Officer> Officer { get; set; }

        //[AllowedExtensions(new string[] { ".jpg", ".png", ".pdf" })]
        public List<IFormFile> ProcedcureUrl { get; set; }
        public string ProcedcureTage { get; set; }
        public DateTime Date { get; private set; } = DateTime.Now;
        public DateTime ReminderDate { get; set; }
        public string Note { get; set; }
    }
}
