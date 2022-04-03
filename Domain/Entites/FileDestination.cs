using System.Collections.Generic;

namespace Domain.Entites
{
    public class FileDestination : BaseEntity
    {
        public string Name { get; set; }
        public virtual IList<Officer> Officers { get; private set; } = new List<Officer>();
        //public virtual IList<FileInfo> Files { get; private set; } = new List<FileInfo>();
    }
}
