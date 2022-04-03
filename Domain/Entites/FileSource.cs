using System.Collections.Generic;

namespace Domain.Entites
{
    public class FileSource : BaseEntity
    {
        public string Name { get; set; }
        public virtual IList<FileInfoSoruce> Files { get; private set; } = new List<FileInfoSoruce>();
    }
}
