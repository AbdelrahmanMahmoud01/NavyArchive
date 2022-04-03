using Domain.Entites;
using System;
using System.Collections.Generic;

namespace UI.ViewModels
{
    public class FileDetailsViewModel
    {
        public int Id { get; set; }
        public string Const { get; set; }
        public int SourceId { get; set; }
        public virtual IList<FileInfoSoruce> FileInfoSoruce { get; set; }
        public IEnumerable<string> SoruceName { get; set; }
        public IEnumerable<string> OfficerName { get; set; }
        public IEnumerable<string> DepartmentName { get; set; }
        public string AboutUrl { get; set; }
        public string AboutTag { get; set; }
        public int OfficerId { get; set; }
        public virtual IList<FileInfoOfficers> FileInfoOfficers { get; set; }
        public string ProcedcureUrl { get; set; }
        public string ProcedcureTage { get; set; }
        public DateTime Date { get; set; }
        public DateTime ReminderDate { get; set; }
        public string Note { get; set; }
    }
}
