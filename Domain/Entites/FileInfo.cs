using System;
using System.Collections.Generic;

namespace Domain.Entites
{
    public class FileInfo : BaseEntity
    {
        public string Const { get; set; }
        public virtual IList<FileInfoSoruce> FileInfoSoruce { get; set; } = new List<FileInfoSoruce>();
        public string AboutUrl { get; set; }
        public string AboutTag { get; set; }
        public virtual IList<FileInfoOfficers> FileInfoOfficers { get; set; } = new List<FileInfoOfficers>();
        public string ProcedcureUrl { get; set; }
        public string ProcedcureTage { get; set; }
        public DateTime Date { get; private set; } = DateTime.Now;
        public DateTime ReminderDate { get; set; } = DateTime.Now;
        public string Note { get; set; }
        public int OfficerId { get; set; }
        public int SourceId { get; set; }
    }
}
